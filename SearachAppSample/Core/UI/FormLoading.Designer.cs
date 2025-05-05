namespace SearachAppSample.Core
{
    partial class FormLoading
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblMsg = new Label();
            progressBar1 = new ProgressBar();
            lblProgress = new Label();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblMsg
            // 
            lblMsg.Font = new Font("メイリオ", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblMsg.Location = new Point(12, 9);
            lblMsg.Name = "lblMsg";
            lblMsg.Size = new Size(416, 80);
            lblMsg.TabIndex = 0;
            lblMsg.Text = "label1";
            lblMsg.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 92);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(416, 30);
            progressBar1.TabIndex = 1;
            // 
            // lblProgress
            // 
            lblProgress.Font = new Font("メイリオ", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblProgress.Location = new Point(12, 125);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(416, 28);
            lblProgress.TabIndex = 2;
            lblProgress.Text = "100%";
            lblProgress.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("メイリオ", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btnCancel.Location = new Point(132, 171);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(177, 50);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "キャンセル";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormLoading
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(440, 230);
            ControlBox = false;
            Controls.Add(btnCancel);
            Controls.Add(lblProgress);
            Controls.Add(progressBar1);
            Controls.Add(lblMsg);
            Name = "FormLoading";
            Text = "FormLoading";
            ResumeLayout(false);
        }

        #endregion

        private Label lblMsg;
        private ProgressBar progressBar1;
        private Label lblProgress;
        private Button btnCancel;
    }
}