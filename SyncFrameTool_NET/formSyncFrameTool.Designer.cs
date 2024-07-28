namespace SyncFrameTool_NET
{
    partial class formSyncFrameTool
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCalculate = new Button();
            cboFrameRate = new ComboBox();
            label2 = new Label();
            lblReferenceTime = new Label();
            groupBox1 = new GroupBox();
            btnEndClearTimes = new Button();
            lblEndFrame = new Label();
            maskEndTime = new MaskedTextBox();
            lblEndTime = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label1 = new Label();
            txtEndSecond = new TextBox();
            txtEndFrame = new TextBox();
            txtEndMinute = new TextBox();
            txtEndHour = new TextBox();
            lblRefErrorMessage = new Label();
            lblResultTime = new Label();
            lblResultFrames = new Label();
            groupBox2 = new GroupBox();
            btnRefClearTime = new Button();
            maskRefTime = new MaskedTextBox();
            lblRefFrame = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            txtRefSecond = new TextBox();
            txtRefFrame = new TextBox();
            txtRefMinute = new TextBox();
            txtRefHour = new TextBox();
            groupBox3 = new GroupBox();
            lblSuggestion = new Label();
            label3 = new Label();
            label13 = new Label();
            lblEndErrorMessage = new Label();
            btnClearAll = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(671, 52);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(94, 35);
            btnCalculate.TabIndex = 2;
            btnCalculate.Text = "Calculate";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // cboFrameRate
            // 
            cboFrameRate.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFrameRate.DropDownWidth = 50;
            cboFrameRate.FormattingEnabled = true;
            cboFrameRate.Items.AddRange(new object[] { "24", "25", "30", "45", "60" });
            cboFrameRate.Location = new Point(12, 43);
            cboFrameRate.Name = "cboFrameRate";
            cboFrameRate.Size = new Size(54, 28);
            cboFrameRate.TabIndex = 3;
            cboFrameRate.SelectedIndexChanged += cboFrameRate_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 28.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(318, 121);
            label2.Name = "label2";
            label2.Size = new Size(54, 54);
            label2.TabIndex = 4;
            label2.Text = "-";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblReferenceTime
            // 
            lblReferenceTime.AutoSize = true;
            lblReferenceTime.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblReferenceTime.Location = new Point(73, 115);
            lblReferenceTime.Name = "lblReferenceTime";
            lblReferenceTime.Size = new Size(151, 41);
            lblReferenceTime.TabIndex = 7;
            lblReferenceTime.Text = "0:00:00:00";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnEndClearTimes);
            groupBox1.Controls.Add(lblEndFrame);
            groupBox1.Controls.Add(maskEndTime);
            groupBox1.Controls.Add(lblEndTime);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtEndSecond);
            groupBox1.Controls.Add(txtEndFrame);
            groupBox1.Controls.Add(txtEndMinute);
            groupBox1.Controls.Add(txtEndHour);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(371, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(249, 280);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Offset Time Frame";
            // 
            // btnEndClearTimes
            // 
            btnEndClearTimes.Location = new Point(7, 121);
            btnEndClearTimes.Name = "btnEndClearTimes";
            btnEndClearTimes.Size = new Size(63, 35);
            btnEndClearTimes.TabIndex = 21;
            btnEndClearTimes.Text = "Clear";
            btnEndClearTimes.UseVisualStyleBackColor = true;
            btnEndClearTimes.Click += btnEndClearTimes_Click;
            // 
            // lblEndFrame
            // 
            lblEndFrame.AutoSize = true;
            lblEndFrame.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            lblEndFrame.Location = new Point(24, 220);
            lblEndFrame.Name = "lblEndFrame";
            lblEndFrame.Size = new Size(117, 38);
            lblEndFrame.TabIndex = 20;
            lblEndFrame.Text = "Frame 0";
            // 
            // maskEndTime
            // 
            maskEndTime.Font = new Font("Segoe UI", 19.2F, FontStyle.Regular, GraphicsUnit.Point);
            maskEndTime.Location = new Point(37, 165);
            maskEndTime.Mask = "00:00:00:00";
            maskEndTime.Name = "maskEndTime";
            maskEndTime.Size = new Size(167, 50);
            maskEndTime.TabIndex = 19;
            maskEndTime.TextAlign = HorizontalAlignment.Center;
            maskEndTime.TextChanged += maskEndTime_TextChanged;
            // 
            // lblEndTime
            // 
            lblEndTime.AutoSize = true;
            lblEndTime.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblEndTime.Location = new Point(73, 115);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.Size = new Size(151, 41);
            lblEndTime.TabIndex = 18;
            lblEndTime.Text = "0:00:00:00";
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(187, 32);
            label7.Name = "label7";
            label7.Size = new Size(53, 33);
            label7.TabIndex = 16;
            label7.Text = "FF";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(127, 32);
            label6.Name = "label6";
            label6.Size = new Size(53, 33);
            label6.TabIndex = 15;
            label6.Text = "SS";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(67, 32);
            label5.Name = "label5";
            label5.Size = new Size(53, 33);
            label5.TabIndex = 14;
            label5.Text = "MM";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(7, 32);
            label1.Name = "label1";
            label1.Size = new Size(53, 33);
            label1.TabIndex = 13;
            label1.Text = "H";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtEndSecond
            // 
            txtEndSecond.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtEndSecond.Location = new Point(127, 69);
            txtEndSecond.MaxLength = 2;
            txtEndSecond.Name = "txtEndSecond";
            txtEndSecond.Size = new Size(53, 43);
            txtEndSecond.TabIndex = 3;
            txtEndSecond.Tag = "End Seconds";
            txtEndSecond.Text = "0";
            txtEndSecond.TextAlign = HorizontalAlignment.Center;
            txtEndSecond.TextChanged += txtEndSecond_TextChanged;
            // 
            // txtEndFrame
            // 
            txtEndFrame.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtEndFrame.Location = new Point(187, 69);
            txtEndFrame.MaxLength = 2;
            txtEndFrame.Name = "txtEndFrame";
            txtEndFrame.Size = new Size(53, 43);
            txtEndFrame.TabIndex = 4;
            txtEndFrame.Tag = "End Frames";
            txtEndFrame.Text = "0";
            txtEndFrame.TextAlign = HorizontalAlignment.Center;
            txtEndFrame.TextChanged += txtEndFrame_TextChanged;
            // 
            // txtEndMinute
            // 
            txtEndMinute.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtEndMinute.Location = new Point(67, 69);
            txtEndMinute.MaxLength = 2;
            txtEndMinute.Name = "txtEndMinute";
            txtEndMinute.Size = new Size(53, 43);
            txtEndMinute.TabIndex = 2;
            txtEndMinute.Tag = "End Minutes";
            txtEndMinute.Text = "0";
            txtEndMinute.TextAlign = HorizontalAlignment.Center;
            txtEndMinute.TextChanged += txtEndMinute_TextChanged;
            // 
            // txtEndHour
            // 
            txtEndHour.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtEndHour.Location = new Point(7, 69);
            txtEndHour.MaxLength = 2;
            txtEndHour.Name = "txtEndHour";
            txtEndHour.Size = new Size(53, 43);
            txtEndHour.TabIndex = 1;
            txtEndHour.Tag = "End Hours";
            txtEndHour.Text = "0";
            txtEndHour.TextAlign = HorizontalAlignment.Center;
            txtEndHour.TextChanged += txtEndHour_TextChanged;
            // 
            // lblRefErrorMessage
            // 
            lblRefErrorMessage.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            lblRefErrorMessage.Location = new Point(72, 295);
            lblRefErrorMessage.Name = "lblRefErrorMessage";
            lblRefErrorMessage.Size = new Size(274, 78);
            lblRefErrorMessage.TabIndex = 10;
            lblRefErrorMessage.Text = "ErrorMessageHere";
            // 
            // lblResultTime
            // 
            lblResultTime.AutoSize = true;
            lblResultTime.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point);
            lblResultTime.Location = new Point(6, 20);
            lblResultTime.Name = "lblResultTime";
            lblResultTime.Size = new Size(186, 50);
            lblResultTime.TabIndex = 12;
            lblResultTime.Text = "0:00:00:00";
            // 
            // lblResultFrames
            // 
            lblResultFrames.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblResultFrames.Location = new Point(12, 70);
            lblResultFrames.Name = "lblResultFrames";
            lblResultFrames.Size = new Size(193, 64);
            lblResultFrames.TabIndex = 13;
            lblResultFrames.Text = "0 Frames";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnRefClearTime);
            groupBox2.Controls.Add(maskRefTime);
            groupBox2.Controls.Add(lblRefFrame);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(txtRefSecond);
            groupBox2.Controls.Add(txtRefFrame);
            groupBox2.Controls.Add(lblReferenceTime);
            groupBox2.Controls.Add(txtRefMinute);
            groupBox2.Controls.Add(txtRefHour);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.Location = new Point(72, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(249, 280);
            groupBox2.TabIndex = 17;
            groupBox2.TabStop = false;
            groupBox2.Text = "Reference Time Frame";
            // 
            // btnRefClearTime
            // 
            btnRefClearTime.Location = new Point(6, 121);
            btnRefClearTime.Name = "btnRefClearTime";
            btnRefClearTime.Size = new Size(63, 35);
            btnRefClearTime.TabIndex = 24;
            btnRefClearTime.Text = "Clear";
            btnRefClearTime.UseVisualStyleBackColor = true;
            btnRefClearTime.Click += btnSetClearTime_Click;
            // 
            // maskRefTime
            // 
            maskRefTime.Font = new Font("Segoe UI", 19.2F, FontStyle.Regular, GraphicsUnit.Point);
            maskRefTime.Location = new Point(45, 165);
            maskRefTime.Mask = "00:00:00:00";
            maskRefTime.Name = "maskRefTime";
            maskRefTime.Size = new Size(167, 50);
            maskRefTime.TabIndex = 23;
            maskRefTime.TextAlign = HorizontalAlignment.Center;
            maskRefTime.TextChanged += maskRefTime_TextChanged;
            // 
            // lblRefFrame
            // 
            lblRefFrame.AutoSize = true;
            lblRefFrame.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            lblRefFrame.Location = new Point(21, 220);
            lblRefFrame.Name = "lblRefFrame";
            lblRefFrame.Size = new Size(117, 38);
            lblRefFrame.TabIndex = 17;
            lblRefFrame.Text = "Frame 0";
            // 
            // label8
            // 
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(187, 32);
            label8.Name = "label8";
            label8.Size = new Size(53, 33);
            label8.TabIndex = 16;
            label8.Text = "FF";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(127, 32);
            label9.Name = "label9";
            label9.Size = new Size(53, 33);
            label9.TabIndex = 15;
            label9.Text = "SS";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(67, 32);
            label10.Name = "label10";
            label10.Size = new Size(53, 33);
            label10.TabIndex = 14;
            label10.Text = "MM";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(7, 32);
            label11.Name = "label11";
            label11.Size = new Size(53, 33);
            label11.TabIndex = 13;
            label11.Text = "H";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtRefSecond
            // 
            txtRefSecond.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtRefSecond.Location = new Point(127, 69);
            txtRefSecond.MaxLength = 2;
            txtRefSecond.Name = "txtRefSecond";
            txtRefSecond.Size = new Size(53, 43);
            txtRefSecond.TabIndex = 3;
            txtRefSecond.Tag = "Reference Seconds";
            txtRefSecond.Text = "0";
            txtRefSecond.TextAlign = HorizontalAlignment.Center;
            txtRefSecond.TextChanged += txtRefSecond_TextChanged;
            // 
            // txtRefFrame
            // 
            txtRefFrame.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtRefFrame.Location = new Point(187, 69);
            txtRefFrame.MaxLength = 2;
            txtRefFrame.Name = "txtRefFrame";
            txtRefFrame.Size = new Size(53, 43);
            txtRefFrame.TabIndex = 4;
            txtRefFrame.Tag = "Reference Frames";
            txtRefFrame.Text = "0";
            txtRefFrame.TextAlign = HorizontalAlignment.Center;
            txtRefFrame.TextChanged += txtRefFrame_TextChanged;
            // 
            // txtRefMinute
            // 
            txtRefMinute.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtRefMinute.Location = new Point(67, 69);
            txtRefMinute.MaxLength = 2;
            txtRefMinute.Name = "txtRefMinute";
            txtRefMinute.Size = new Size(53, 43);
            txtRefMinute.TabIndex = 2;
            txtRefMinute.Tag = "Reference Minutes";
            txtRefMinute.Text = "0";
            txtRefMinute.TextAlign = HorizontalAlignment.Center;
            txtRefMinute.TextChanged += txtRefMinute_TextChanged;
            // 
            // txtRefHour
            // 
            txtRefHour.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtRefHour.Location = new Point(7, 69);
            txtRefHour.MaxLength = 2;
            txtRefHour.Name = "txtRefHour";
            txtRefHour.Size = new Size(53, 43);
            txtRefHour.TabIndex = 1;
            txtRefHour.Tag = "Reference Hours";
            txtRefHour.Text = "0";
            txtRefHour.TextAlign = HorizontalAlignment.Center;
            txtRefHour.TextChanged += txtRefHour_TextChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lblResultFrames);
            groupBox3.Controls.Add(lblResultTime);
            groupBox3.Controls.Add(lblSuggestion);
            groupBox3.Location = new Point(663, 102);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(225, 219);
            groupBox3.TabIndex = 18;
            groupBox3.TabStop = false;
            groupBox3.Text = "Adjustment Time";
            // 
            // lblSuggestion
            // 
            lblSuggestion.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            lblSuggestion.Location = new Point(6, 134);
            lblSuggestion.Name = "lblSuggestion";
            lblSuggestion.Size = new Size(215, 82);
            lblSuggestion.TabIndex = 21;
            lblSuggestion.Text = "Adjust the clip to the right/left. It is ahead/behind the target.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 12);
            label3.Name = "label3";
            label3.Size = new Size(44, 28);
            label3.TabIndex = 5;
            label3.Text = "FPS";
            // 
            // label13
            // 
            label13.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(626, 121);
            label13.Name = "label13";
            label13.Size = new Size(43, 45);
            label13.TabIndex = 20;
            label13.Text = "=";
            label13.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblEndErrorMessage
            // 
            lblEndErrorMessage.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            lblEndErrorMessage.Location = new Point(371, 295);
            lblEndErrorMessage.Name = "lblEndErrorMessage";
            lblEndErrorMessage.Size = new Size(273, 78);
            lblEndErrorMessage.TabIndex = 22;
            lblEndErrorMessage.Text = "ErrorMessageHere";
            // 
            // btnClearAll
            // 
            btnClearAll.Location = new Point(790, 52);
            btnClearAll.Name = "btnClearAll";
            btnClearAll.Size = new Size(94, 35);
            btnClearAll.TabIndex = 23;
            btnClearAll.Text = "Clear All";
            btnClearAll.UseVisualStyleBackColor = true;
            btnClearAll.Click += btnClearAll_Click;
            // 
            // formSyncFrameTool
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(898, 382);
            Controls.Add(btnClearAll);
            Controls.Add(lblEndErrorMessage);
            Controls.Add(label13);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(lblRefErrorMessage);
            Controls.Add(groupBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cboFrameRate);
            Controls.Add(btnCalculate);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "formSyncFrameTool";
            Text = "Sync Video Clip";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnCalculate;
        private ComboBox cboFrameRate;
        private Label label2;
        private Label lblReferenceTime;
        private GroupBox groupBox1;
        private TextBox txtEndHour;
        private TextBox txtEndSecond;
        private TextBox txtEndMinute;
        private TextBox txtEndFrame;
        private Label label1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label lblRefErrorMessage;
        private Label lblResultTime;
        private Label lblResultFrames;
        private GroupBox groupBox2;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox txtRefSecond;
        private TextBox txtRefFrame;
        private TextBox txtRefMinute;
        private TextBox txtRefHour;
        private Label lblRefFrame;
        private GroupBox groupBox3;
        private Label label3;
        private Label label13;
        private Label lblSuggestion;
        private Label lblEndErrorMessage;
        private Label lblEndTime;
        private MaskedTextBox maskEndTime;
        private Label lblEndFrame;
        private Button btnEndClearTimes;
        private MaskedTextBox maskRefTime;
        private Button btnRefClearTime;
        private Button btnClearAll;
    }
}