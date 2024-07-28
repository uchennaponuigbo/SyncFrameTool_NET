using System.Text;

namespace SyncFrameTool_NET
{
    public partial class formSyncFrameTool : Form
    {
        private ManageVideoTimerFrame videoTimerFrame;
        private VideoTimer referenceTimeToken;
        private VideoTimer endTimeToken;
        //bool[] timeEndErrors;
        //bool[] timeRefErrors;
        private DisplayTimeError displayRefErrors;
        private DisplayTimeError displayEndErrors;
        private const ushort HourLimit = 24;

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

            //timeEndErrors = timeRefErrors = new bool[4]; //true if there is an error        
            displayRefErrors = new DisplayTimeError();
            displayEndErrors = new DisplayTimeError();
            referenceTimeToken = new VideoTimer();
            endTimeToken = new VideoTimer();

            cboFrameRate.SelectedIndexChanged -= cboFrameRate_SelectedIndexChanged;
            cboFrameRate.SelectedIndex = 2;

            videoTimerFrame = new ManageVideoTimerFrame((Convert.ToUInt16(cboFrameRate.SelectedItem)));

            cboFrameRate.SelectedIndexChanged += cboFrameRate_SelectedIndexChanged;

            lblRefErrorMessage.Text = lblEndErrorMessage.Text = lblSuggestion.Text = "";
        }

        //TODO: Calculations break after the offset in hours are really large.
        //So far, I pinpointed the problem to this method, where we call the functions
        //to do the time calculations. This will be done on another day

        //My theory is that there is an overflow somewhere. I use ushorts for the indidivual
        //time values and at the time, the highest hour value was 9, but I expanded that to 23
        //and that's when the issues popped up

        //max value of ushort: 65,535

        //Solution: It was an overflow after messing with the hours variable and seeing the point where
        //the result would return a smaller time value than expected. I'd have to change the
        //ushort in the struct to uint to fix (16bit -> 32bit)
        //as I was about to do that, I realize that it'd possibly break more compatible functions in this file
        //so instead, I stored a uint temp seconds variable to prevent overflowing, then set that to the
        //struct value once the number is small enough

        //this problem only began to happen because I increased the hour value limit.
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int adjustmentFrames = videoTimerFrame.DeltaFrameOffset(referenceTimeToken, endTimeToken);
            VideoTimer adjustmentTimer =
                videoTimerFrame.ConvertFrameCountToVideoTime(adjustmentFrames);
            if (adjustmentFrames != 1)
                lblResultFrames.Text = $"{adjustmentFrames} Frames";
            else
                lblResultFrames.Text = $"{adjustmentFrames} Frame";
            lblResultTime.Text = adjustmentTimer.ToString();

            if (adjustmentFrames < 0)
                lblSuggestion.Text = "Move the clip to the right. It is behind the target.";
            else if (adjustmentFrames > 0)
                lblSuggestion.Text = "Move the clip to the left. It is ahead of the target.";
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

        //TODO: Currently, it only displays one error message at a time, if another error occurs,
        //then it is overriden.

        //I've been wanting to display all the errors and only remove the errors that have been fixed
        //Gonna tackle this problem again
        //private void CheckTimeTextBoxes(ref TextBox txtTime, ref bool timeError,
        //    ref VideoTimer token, ref Label errorMessage, CheckTime time, ushort range)
        //{
        //    if (Validator.IsEmpty(txtTime))
        //    {
        //        AdjustCorrectTime(ref token, 0, time);
        //        errorMessage.Text = "";
        //        timeError = false;
        //        return;
        //    }

        //    if (Validator.IsInteger(txtTime.Text))
        //    {
        //        if (Validator.IsWithinRange(txtTime, 0, range))
        //        {
        //            AdjustCorrectTime(ref token, Convert.ToUInt16(txtTime.Text), time);
        //            errorMessage.Text = "";
        //            timeError = false;
        //        }
        //        else
        //        {
        //            txtTime.Text = (range - 1).ToString();
        //            AdjustCorrectTime(ref token, Convert.ToUInt16(txtTime.Text), time);
        //            errorMessage.Text = $"{txtTime.Tag} was not in range. Adjusted to preset range";
        //            timeError = false;
        //        }

        //    }
        //    else
        //    {
        //        errorMessage.Text = $"{txtTime.Tag} is NaN";
        //        timeError = true;
        //        return;
        //    }
        //}

        //private void CheckForInputErrors(ref bool[] timeErrors, ref Label lblTime,
        //    ref VideoTimer token, ref Label lblFrameCount)
        //{
        //    for (int i = 0; i < timeErrors.Length; i++)
        //    {
        //        if (timeErrors[i])
        //        {
        //            btnCalculate.Enabled = false;
        //            return;
        //        }
        //    }
        //    btnCalculate.Enabled = true;
        //    DisplayTimeInfo(ref lblTime, token, ref lblFrameCount);
        //}

        //TODO: fix bug where the calculate button will be enabled despite having a NaN value in one
        //of the text boxes
        //Update: Could be a copy code bug. to reproduce, type letters in ref text boxes, then
        //go out of range in the end hours textbox. The NaN error messages will pop up in the End
        //errors label
        //It also works in reverse, if I do the txt times then go out of range on the reference times

        //SOLUTION: I FORGOT ABOUT THIS
        //displayRefErrors = displayEndErrors = new DisplayTimeError()
        //DO NOT DO THIS. THE POINTERS GO TO THE SAME MEMORY ADDRESS
        private void CheckTimeTextBoxes(ref TextBox txtTime, int index, ref DisplayTimeError display,
            ref VideoTimer token, ref Label errorMessage,
            CheckTime time, ushort range)
        {
            if (Validator.IsEmpty(txtTime))
            {
                AdjustCorrectTime(ref token, 0, time);
                display.SetMessages(index, false, "");
                errorMessage.Text = display.ToString();
                return;
            }

            if (Validator.IsInteger(txtTime.Text))
            {
                if (Validator.IsWithinRange(txtTime, 0, range))
                {
                    AdjustCorrectTime(ref token, Convert.ToUInt16(txtTime.Text), time);
                    display.SetMessages(index, false, "");
                    errorMessage.Text = display.ToString();
                }
                else
                {
                    txtTime.Text = (range - 1).ToString();
                    AdjustCorrectTime(ref token, Convert.ToUInt16(txtTime.Text), time);
                    display.SetMessages(index, false, $"Adjusted {txtTime.Tag} to preset range.");
                    errorMessage.Text = display.ToString();
                }

            }
            else
            {
                display.SetMessages(index, true, $"{txtTime.Tag} is NaN.");
                errorMessage.Text = display.ToString();
                return;
            }
        }

        private void CheckForInputErrors(ref DisplayTimeError display, ref Label lblTime,
            ref VideoTimer token, ref Label lblFrameCount)
        {
            if (display.AreThereInputErrors())
            {
                btnCalculate.Enabled = false;
                return;
            }
            btnCalculate.Enabled = true;
            DisplayTimeInfo(ref lblTime, token, ref lblFrameCount);
        }

        private void DisplayTimeInfo(ref Label lblTime, VideoTimer token, ref Label lblFrameCount)
        {
            lblTime.Text = token.ToString();
            lblFrameCount.Text =
                $"Frame {videoTimerFrame.ConvertVideoTimeToFrameCount(token)}";
        }

        private void txtEndHour_TextChanged(object sender, EventArgs e)
        {
            //CheckTimeTextBoxes(ref txtEndHour, ref timeEndErrors[0],
            //    ref endTimeToken, ref lblEndErrorMessage, CheckTime.Hour, HourLimit);
            //CheckForInputErrors(ref timeEndErrors,
            //    ref lblEndTime, ref endTimeToken, ref lblEndFrame);
            CheckTimeTextBoxes(ref txtEndHour, 0, ref displayEndErrors,
                ref endTimeToken, ref lblEndErrorMessage, CheckTime.Hour, HourLimit);
            CheckForInputErrors(ref displayEndErrors, ref lblEndTime,
                ref endTimeToken, ref lblEndFrame);
        }

        private void txtEndMinute_TextChanged(object sender, EventArgs e)
        {
            //CheckTimeTextBoxes(ref txtEndMinute, ref timeEndErrors[1],
            //    ref endTimeToken, ref lblEndErrorMessage, CheckTime.Minute, 60);
            //CheckForInputErrors(ref timeEndErrors,
            //    ref lblEndTime, ref endTimeToken, ref lblEndFrame);

            CheckTimeTextBoxes(ref txtEndMinute, 1, ref displayEndErrors,
                ref endTimeToken, ref lblEndErrorMessage, CheckTime.Minute, 60);
            CheckForInputErrors(ref displayEndErrors, ref lblEndTime,
                ref endTimeToken, ref lblEndFrame);
        }

        private void txtEndSecond_TextChanged(object sender, EventArgs e)
        {
            //CheckTimeTextBoxes(ref txtEndSecond, ref timeEndErrors[2],
            //    ref endTimeToken, ref lblEndErrorMessage, CheckTime.Second, 60);
            //CheckForInputErrors(ref timeEndErrors,
            //    ref lblEndTime, ref endTimeToken, ref lblEndFrame);
            CheckTimeTextBoxes(ref txtEndSecond, 2, ref displayEndErrors,
                ref endTimeToken, ref lblEndErrorMessage, CheckTime.Second, 60);
            CheckForInputErrors(ref displayEndErrors, ref lblEndTime,
                ref endTimeToken, ref lblEndFrame);
        }

        private void txtEndFrame_TextChanged(object sender, EventArgs e)
        {
            //CheckTimeTextBoxes(ref txtEndFrame, ref timeEndErrors[3],
            //    ref endTimeToken, ref lblEndErrorMessage, CheckTime.Frame, videoTimerFrame.FPS);
            //CheckForInputErrors(ref timeEndErrors,
            //    ref lblEndTime, ref endTimeToken, ref lblEndFrame);
            CheckTimeTextBoxes(ref txtEndFrame, 3, ref displayEndErrors,
                ref endTimeToken, ref lblEndErrorMessage, CheckTime.Frame, videoTimerFrame.FPS);
            CheckForInputErrors(ref displayEndErrors, ref lblEndTime,
                ref endTimeToken, ref lblEndFrame);
        }

        private void cboFrameRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            videoTimerFrame.FPS = Convert.ToUInt16(cboFrameRate.SelectedItem.ToString());

            if (Validator.IsInteger(txtRefFrame.Text))
            {
                ushort refFrameRate = Convert.ToUInt16(txtRefFrame.Text);
                if (refFrameRate >= videoTimerFrame.FPS)
                {
                    refFrameRate = (ushort)(videoTimerFrame.FPS - 1);
                    txtRefFrame.Text = refFrameRate.ToString();

                    lblSuggestion.Text = "";
                    lblResultFrames.Text = "0 Frames";
                    lblResultTime.Text = "0:00:00:00";
                }
            }

            if (Validator.IsInteger(txtEndFrame.Text))
            {
                ushort endFrameRate = Convert.ToUInt16(txtEndFrame.Text);
                if (endFrameRate >= videoTimerFrame.FPS)
                {
                    endFrameRate = (ushort)(videoTimerFrame.FPS - 1);
                    txtEndFrame.Text = endFrameRate.ToString();

                    lblSuggestion.Text = "";
                    lblResultFrames.Text = "0 Frames";
                    lblResultTime.Text = "0:00:00:00";
                }
            }

            DisplayTimeInfo(ref lblReferenceTime, referenceTimeToken, ref lblRefFrame);
            DisplayTimeInfo(ref lblEndTime, endTimeToken, ref lblEndFrame);
        }

        private void txtRefHour_TextChanged(object sender, EventArgs e)
        {
            //CheckTimeTextBoxes(ref txtRefHour, ref timeRefErrors[0],
            //    ref referenceTimeToken, ref lblRefErrorMessage, CheckTime.Hour, HourLimit);
            //CheckForInputErrors(ref timeRefErrors,
            //    ref lblReferenceTime, ref referenceTimeToken, ref lblRefFrame);
            CheckTimeTextBoxes(ref txtRefHour, 0, ref displayRefErrors,
                ref referenceTimeToken, ref lblRefErrorMessage, CheckTime.Hour, HourLimit);
            CheckForInputErrors(ref displayRefErrors, ref lblReferenceTime,
                ref referenceTimeToken, ref lblRefFrame);
        }

        private void txtRefMinute_TextChanged(object sender, EventArgs e)
        {
            //CheckTimeTextBoxes(ref txtRefMinute, ref timeRefErrors[1],
            //    ref referenceTimeToken, ref lblRefErrorMessage, CheckTime.Minute, 60);
            //CheckForInputErrors(ref timeRefErrors,
            //    ref lblReferenceTime, ref referenceTimeToken, ref lblRefFrame);
            CheckTimeTextBoxes(ref txtRefMinute, 1, ref displayRefErrors,
                ref referenceTimeToken, ref lblRefErrorMessage, CheckTime.Minute, 60);
            CheckForInputErrors(ref displayRefErrors, ref lblReferenceTime,
                ref referenceTimeToken, ref lblRefFrame);
        }

        private void txtRefSecond_TextChanged(object sender, EventArgs e)
        {
            //CheckTimeTextBoxes(ref txtRefSecond, ref timeRefErrors[2],
            //    ref referenceTimeToken, ref lblRefErrorMessage, CheckTime.Second, 60);
            //CheckForInputErrors(ref timeRefErrors,
            //    ref lblReferenceTime, ref referenceTimeToken, ref lblRefFrame);
            CheckTimeTextBoxes(ref txtRefSecond, 2, ref displayRefErrors,
                ref referenceTimeToken, ref lblRefErrorMessage, CheckTime.Second, 60);
            CheckForInputErrors(ref displayRefErrors, ref lblReferenceTime,
                ref referenceTimeToken, ref lblRefFrame);
        }

        private void txtRefFrame_TextChanged(object sender, EventArgs e)
        {
            //CheckTimeTextBoxes(ref txtRefFrame, ref timeRefErrors[3],
            //    ref referenceTimeToken, ref lblRefErrorMessage, CheckTime.Frame, videoTimerFrame.FPS);
            //CheckForInputErrors(ref timeRefErrors,
            //    ref lblReferenceTime, ref referenceTimeToken, ref lblRefFrame);
            CheckTimeTextBoxes(ref txtRefFrame, 3, ref displayRefErrors,
                ref referenceTimeToken, ref lblRefErrorMessage, CheckTime.Frame, videoTimerFrame.FPS);
            CheckForInputErrors(ref displayRefErrors, ref lblReferenceTime,
                ref referenceTimeToken, ref lblRefFrame);
        }

        private void ParseTimeIntoTextBoxes(MaskedTextBox maskTime, ref TextBox txtHour,
            ref TextBox txtMinute, ref TextBox txtSecond, ref TextBox txtFrame)
        {
            //copy and paste in times from shotcut
            //split the string by colons
            //place in correct textboxes
            //the textchanged events on the textboxes will run automatically and do
            //time adjustments
            string[] times = maskTime.Text.Split(':');
            for (int i = 0; i < times.Length; i++)
            {
                if (times[i] == "  " || times[i] == "")
                    times[i] = "0";
            }

            txtHour.Text = times[0];
            txtMinute.Text = times[1];
            txtSecond.Text = times[2];
            txtFrame.Text = times[3];
        }

        private void maskEndTime_TextChanged(object sender, EventArgs e)
        {
            ParseTimeIntoTextBoxes(maskEndTime, ref txtEndHour, ref txtEndMinute,
                ref txtEndSecond, ref txtEndFrame);
        }
        private void maskRefTime_TextChanged(object sender, EventArgs e)
        {
            ParseTimeIntoTextBoxes(maskRefTime, ref txtRefHour, ref txtRefMinute,
                ref txtRefSecond, ref txtRefFrame);
        }

        private void ResetFields(ref VideoTimer token, ref MaskedTextBox maskTime, ref TextBox txtHour,
            ref TextBox txtMinute, ref TextBox txtSecond, ref TextBox txtFrame)
        {
            token.SetToZero();
            maskTime.Text = "";
            txtHour.Text = txtMinute.Text = txtSecond.Text = txtFrame.Text = "0";

            lblSuggestion.Text = "";
            lblResultFrames.Text = "0 Frames";
            lblResultTime.Text = "0:00:00:00";
        }

        private void btnEndClearTimes_Click(object sender, EventArgs e)
        {
            //unsubscribe from event to prevent running unneccsary function
            maskEndTime.TextChanged -= maskEndTime_TextChanged;
            ResetFields(ref endTimeToken, ref maskEndTime, ref txtEndHour,
                ref txtEndMinute, ref txtEndSecond, ref txtEndFrame);
            maskEndTime.TextChanged += maskEndTime_TextChanged;
        }

        private void btnSetClearTime_Click(object sender, EventArgs e)
        {
            maskRefTime.TextChanged -= maskRefTime_TextChanged;
            ResetFields(ref referenceTimeToken, ref maskRefTime, ref txtRefHour,
                ref txtRefMinute, ref txtRefSecond, ref txtRefFrame);
            maskRefTime.TextChanged += maskRefTime_TextChanged;
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            btnRefClearTime.PerformClick();
            btnEndClearTimes.PerformClick();
        }
    }
}