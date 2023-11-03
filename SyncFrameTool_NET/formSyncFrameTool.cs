using System.Text;

namespace SyncFrameTool_NET
{
    public partial class formSyncFrameTool : Form
    {
        private ManageVideoTimerFrame videoTimerFrame;
        private VideoTimer referenceTimeToken;
        private VideoTimer endTimeToken;
        bool[] timeEndErrors;
        bool[] timeRefErrors;

        enum CheckTime
        {
            Hour,
            Minute,
            Second,
            Frame
        }

        public formSyncFrameTool()
        {
            InitializeComponent();

            timeEndErrors = timeRefErrors = new bool[4]; //true if there is an error        

            referenceTimeToken = new VideoTimer();
            endTimeToken = new VideoTimer();

            cboFrameRate.SelectedIndexChanged -= cboFrameRate_SelectedIndexChanged;
            cboFrameRate.SelectedIndex = 2;

            videoTimerFrame = new ManageVideoTimerFrame((Convert.ToUInt16(cboFrameRate.SelectedItem)));

            cboFrameRate.SelectedIndexChanged += cboFrameRate_SelectedIndexChanged;

            lblRefErrorMessage.Text = lblEndErrorMessage.Text = lblSuggestion.Text = "";
        }

        private void btnSetReferenceTime_Click(object sender, EventArgs e)
        {
            lblReferenceTime.Text = referenceTimeToken.ToString();
            lblRefFrame.Text =
                $"Frame {videoTimerFrame.ConvertVideoTimeToFrameCount(referenceTimeToken)}";
            lblSuggestion.Text = "";
            lblResultFrames.Text = "0 Frame(s)";
            lblResultTime.Text = "0:00:00.00";
            //there doesn't need to be a private instantation of a VideoTimer struct instance,
            //can create it here and plug it into the class from the variables

            //however, I'd have to do extra work doing the same work (checking if the text
            //box is empty again). I've already done "extra work" I feel, so I'll not do that.
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int adjustmentFrames = videoTimerFrame.FrameOffset(referenceTimeToken, endTimeToken);
            VideoTimer adjustmentTimer =
                videoTimerFrame.
                    ConvertFrameCountToVideoTime(Math.Abs(adjustmentFrames));

            lblResultFrames.Text = $"{adjustmentFrames} Frame(s)";
            lblResultTime.Text = adjustmentTimer.ToString();

            if (adjustmentFrames < 0)
                lblSuggestion.Text = "Move the clip to the right.";
            else if (adjustmentFrames > 0)
                lblSuggestion.Text = "Move the clip to the left.";
            else
                lblSuggestion.Text = "The clip stays where it is.";
        }

        private void AdjustCorrectTime(ref VideoTimer token, ushort timeValue, CheckTime time)
        {
            switch (time)
            {
                case CheckTime.Hour:
                    token.hours = timeValue;
                    break;
                case CheckTime.Minute:
                    token.minutes = timeValue;
                    break;
                case CheckTime.Second:
                    token.seconds = timeValue;
                    break;
                case CheckTime.Frame:
                    token.frames = timeValue;
                    break;
            }
        }

        private void CheckTimeTextBoxes(ref TextBox txtTime, ref bool timeError,
            ref VideoTimer token, ref Label errorMessage, CheckTime time, ushort range)
        {
            if (Validator.IsEmpty(txtTime))
            {
                AdjustCorrectTime(ref token, 0, time);
                errorMessage.Text = "";
                timeError = false;
                return;
            }

            if (Validator.IsInteger(txtTime.Text))
            {
                if (Validator.IsWithinRange(txtTime, 0, range))
                {
                    AdjustCorrectTime(ref token, Convert.ToUInt16(txtTime.Text), time);
                    errorMessage.Text = "";
                    timeError = false;
                }
                else
                {
                    txtTime.Text = (range - 1).ToString();
                    AdjustCorrectTime(ref token, Convert.ToUInt16(txtTime.Text), time);
                    errorMessage.Text = $"{txtTime.Tag} was not in range. Adjusted to preset range";
                    timeError = false;
                }

            }
            else
            {
                errorMessage.Text = $"{txtTime.Tag} is NaN";
                timeError = true;
                return;
            }
        }

        private void CheckForInputErrors(ref bool[] timeErrors, ref Button btnSetter)
        {
            for (int i = 0; i < timeErrors.Length; i++)
            {
                if (timeErrors[i])
                {
                    btnSetter.Enabled = false;
                    return;
                }
            }
            btnSetter.Enabled = true;
        }

        private void txtEndHour_TextChanged(object sender, EventArgs e)
        {
            CheckTimeTextBoxes(ref txtEndHour, ref timeEndErrors[0],
                ref endTimeToken, ref lblEndErrorMessage, CheckTime.Hour, 10);
            CheckForInputErrors(ref timeEndErrors, ref btnCalculate);
        }

        private void txtEndMinute_TextChanged(object sender, EventArgs e)
        {
            CheckTimeTextBoxes(ref txtEndMinute, ref timeEndErrors[1],
                ref endTimeToken, ref lblEndErrorMessage, CheckTime.Minute, 60);
            CheckForInputErrors(ref timeEndErrors, ref btnCalculate);
        }

        private void txtEndSecond_TextChanged(object sender, EventArgs e)
        {
            CheckTimeTextBoxes(ref txtEndSecond, ref timeEndErrors[2],
                ref endTimeToken, ref lblEndErrorMessage, CheckTime.Second, 60);
            CheckForInputErrors(ref timeEndErrors, ref btnCalculate);
        }

        private void txtEndFrame_TextChanged(object sender, EventArgs e)
        {
            CheckTimeTextBoxes(ref txtEndFrame, ref timeEndErrors[3],
                ref endTimeToken, ref lblEndErrorMessage, CheckTime.Frame, videoTimerFrame.FPS);
            CheckForInputErrors(ref timeEndErrors, ref btnCalculate);
        }

        private void cboFrameRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblRefErrorMessage.Text = cboFrameRate.SelectedItem.ToString();
            videoTimerFrame.FPS = Convert.ToUInt16(cboFrameRate.SelectedItem.ToString());

            if (Validator.IsInteger(txtRefFrame.Text))
            {
                ushort refFrameRate = Convert.ToUInt16(txtRefFrame.Text);
                if (refFrameRate >= videoTimerFrame.FPS)
                {
                    refFrameRate = (ushort)(videoTimerFrame.FPS - 1);
                    txtRefFrame.Text = refFrameRate.ToString();
                    btnSetReferenceTime.PerformClick();
                }
            }

            if (Validator.IsInteger(txtEndFrame.Text))
            {
                ushort endFrameRate = Convert.ToUInt16(txtEndFrame.Text);
                if (endFrameRate >= videoTimerFrame.FPS)
                {
                    endFrameRate = (ushort)(videoTimerFrame.FPS - 1);
                    txtEndFrame.Text = endFrameRate.ToString();
                }
            }
        }

        private void txtRefHour_TextChanged(object sender, EventArgs e)
        {
            CheckTimeTextBoxes(ref txtRefHour, ref timeRefErrors[0],
                ref referenceTimeToken, ref lblRefErrorMessage, CheckTime.Hour, 10);
            CheckForInputErrors(ref timeRefErrors, ref btnSetReferenceTime);
        }

        private void txtRefMinute_TextChanged(object sender, EventArgs e)
        {
            CheckTimeTextBoxes(ref txtRefMinute, ref timeRefErrors[1],
                ref referenceTimeToken, ref lblRefErrorMessage, CheckTime.Minute, 60);
            CheckForInputErrors(ref timeRefErrors, ref btnSetReferenceTime);
        }

        private void txtRefSecond_TextChanged(object sender, EventArgs e)
        {
            CheckTimeTextBoxes(ref txtRefSecond, ref timeRefErrors[2],
                ref referenceTimeToken, ref lblRefErrorMessage, CheckTime.Second, 60);
            CheckForInputErrors(ref timeRefErrors, ref btnSetReferenceTime);
        }

        private void txtRefFrame_TextChanged(object sender, EventArgs e)
        {
            CheckTimeTextBoxes(ref txtRefFrame, ref timeRefErrors[3],
                ref referenceTimeToken, ref lblRefErrorMessage, CheckTime.Frame, videoTimerFrame.FPS);
            CheckForInputErrors(ref timeRefErrors, ref btnSetReferenceTime);
        }
    }
}