namespace SearachAppSample.Pages
{
    partial class UcPageMain
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            btnPN = new Button();
            btnBN = new Button();
            btnSN = new Button();
            btnKatamei = new Button();
            btnChuban = new Button();
            btnKouban = new Button();
            ucItemHeader2 = new SearachAppSample.Items.UcItemHeader();
            button1 = new Button();
            SuspendLayout();
            // 
            // btnPN
            // 
            btnPN.BackColor = Color.SteelBlue;
            btnPN.FlatStyle = FlatStyle.Flat;
            btnPN.Font = new Font("メイリオ", 21.75F);
            btnPN.ForeColor = Color.White;
            btnPN.Location = new Point(379, 462);
            btnPN.Name = "btnPN";
            btnPN.Size = new Size(299, 104);
            btnPN.TabIndex = 12;
            btnPN.Text = "▶ P/Nから検索";
            btnPN.UseVisualStyleBackColor = false;
            // 
            // btnBN
            // 
            btnBN.BackColor = Color.SteelBlue;
            btnBN.FlatStyle = FlatStyle.Flat;
            btnBN.Font = new Font("メイリオ", 21.75F);
            btnBN.ForeColor = Color.White;
            btnBN.Location = new Point(41, 462);
            btnBN.Name = "btnBN";
            btnBN.Size = new Size(299, 104);
            btnBN.TabIndex = 11;
            btnBN.Text = "▶ B/Nから検索";
            btnBN.UseVisualStyleBackColor = false;
            // 
            // btnSN
            // 
            btnSN.BackColor = Color.SteelBlue;
            btnSN.FlatStyle = FlatStyle.Flat;
            btnSN.Font = new Font("メイリオ", 21.75F);
            btnSN.ForeColor = Color.White;
            btnSN.Location = new Point(735, 85);
            btnSN.Name = "btnSN";
            btnSN.Size = new Size(299, 104);
            btnSN.TabIndex = 10;
            btnSN.Text = "▶ S/Nから検索";
            btnSN.UseVisualStyleBackColor = false;
            // 
            // btnKatamei
            // 
            btnKatamei.BackColor = Color.SteelBlue;
            btnKatamei.FlatStyle = FlatStyle.Flat;
            btnKatamei.Font = new Font("メイリオ", 21.75F);
            btnKatamei.ForeColor = Color.White;
            btnKatamei.Location = new Point(41, 261);
            btnKatamei.Name = "btnKatamei";
            btnKatamei.Size = new Size(299, 104);
            btnKatamei.TabIndex = 9;
            btnKatamei.Text = "▶ 型名から検索";
            btnKatamei.UseVisualStyleBackColor = false;
            // 
            // btnChuban
            // 
            btnChuban.BackColor = Color.SteelBlue;
            btnChuban.FlatStyle = FlatStyle.Flat;
            btnChuban.Font = new Font("メイリオ", 21.75F);
            btnChuban.ForeColor = Color.White;
            btnChuban.Location = new Point(379, 85);
            btnChuban.Name = "btnChuban";
            btnChuban.Size = new Size(299, 104);
            btnChuban.TabIndex = 8;
            btnChuban.Text = "▶ 注番から検索";
            btnChuban.UseVisualStyleBackColor = false;
            // 
            // btnKouban
            // 
            btnKouban.BackColor = Color.SteelBlue;
            btnKouban.FlatStyle = FlatStyle.Flat;
            btnKouban.Font = new Font("メイリオ", 21.75F);
            btnKouban.ForeColor = Color.White;
            btnKouban.Location = new Point(41, 85);
            btnKouban.Name = "btnKouban";
            btnKouban.Size = new Size(299, 104);
            btnKouban.TabIndex = 7;
            btnKouban.Text = "▶ 工番から検索";
            btnKouban.UseVisualStyleBackColor = false;
            // 
            // ucItemHeader2
            // 
            ucItemHeader2.BackColor = Color.FromArgb(43, 79, 107);
            ucItemHeader2.Dock = DockStyle.Top;
            ucItemHeader2.Location = new Point(0, 0);
            ucItemHeader2.Name = "ucItemHeader2";
            ucItemHeader2.Size = new Size(1350, 33);
            ucItemHeader2.TabIndex = 13;
            ucItemHeader2.Title = "Title";
            // 
            // button1
            // 
            button1.BackColor = Color.SteelBlue;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("メイリオ", 21.75F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(735, 462);
            button1.Name = "button1";
            button1.Size = new Size(299, 104);
            button1.TabIndex = 14;
            button1.Text = "▶ P/Nから検索";
            button1.UseVisualStyleBackColor = false;
            // 
            // UcPageMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(button1);
            Controls.Add(ucItemHeader2);
            Controls.Add(btnPN);
            Controls.Add(btnBN);
            Controls.Add(btnSN);
            Controls.Add(btnKatamei);
            Controls.Add(btnChuban);
            Controls.Add(btnKouban);
            Name = "UcPageMain";
            Size = new Size(1350, 780);
            ResumeLayout(false);
        }

        #endregion
        private Button btnPN;
        private Button btnBN;
        private Button btnSN;
        private Button btnKatamei;
        private Button btnChuban;
        private Button btnKouban;
        private Items.UcItemHeader ucItemHeader1;
        private Items.UcItemHeader ucItemHeader2;
        private Button button1;
    }
}
