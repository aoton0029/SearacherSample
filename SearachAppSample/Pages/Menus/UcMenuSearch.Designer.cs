namespace SearachAppSample.Pages.Menus
{
    partial class UcMenuSearch
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
            SuspendLayout();
            // 
            // btnPN
            // 
            btnPN.BackColor = Color.SteelBlue;
            btnPN.FlatStyle = FlatStyle.Flat;
            btnPN.Font = new Font("メイリオ", 21.75F);
            btnPN.ForeColor = Color.White;
            btnPN.Location = new Point(614, 134);
            btnPN.Margin = new Padding(5);
            btnPN.Name = "btnPN";
            btnPN.Size = new Size(289, 104);
            btnPN.TabIndex = 18;
            btnPN.Text = "▶ P/Nから検索";
            btnPN.UseVisualStyleBackColor = false;
            btnPN.Click += btnPN_Click;
            // 
            // btnBN
            // 
            btnBN.BackColor = Color.SteelBlue;
            btnBN.FlatStyle = FlatStyle.Flat;
            btnBN.Font = new Font("メイリオ", 21.75F);
            btnBN.ForeColor = Color.White;
            btnBN.Location = new Point(315, 134);
            btnBN.Margin = new Padding(5);
            btnBN.Name = "btnBN";
            btnBN.Size = new Size(289, 104);
            btnBN.TabIndex = 17;
            btnBN.Text = "▶ B/Nから検索";
            btnBN.UseVisualStyleBackColor = false;
            btnBN.Click += btnBN_Click;
            // 
            // btnSN
            // 
            btnSN.BackColor = Color.SteelBlue;
            btnSN.FlatStyle = FlatStyle.Flat;
            btnSN.Font = new Font("メイリオ", 21.75F);
            btnSN.ForeColor = Color.White;
            btnSN.Location = new Point(16, 134);
            btnSN.Margin = new Padding(5);
            btnSN.Name = "btnSN";
            btnSN.Size = new Size(289, 104);
            btnSN.TabIndex = 16;
            btnSN.Text = "▶ S/Nから検索";
            btnSN.UseVisualStyleBackColor = false;
            btnSN.Click += btnSN_Click;
            // 
            // btnKatamei
            // 
            btnKatamei.BackColor = Color.SteelBlue;
            btnKatamei.FlatStyle = FlatStyle.Flat;
            btnKatamei.Font = new Font("メイリオ", 21.75F);
            btnKatamei.ForeColor = Color.White;
            btnKatamei.Location = new Point(614, 20);
            btnKatamei.Margin = new Padding(5);
            btnKatamei.Name = "btnKatamei";
            btnKatamei.Size = new Size(289, 104);
            btnKatamei.TabIndex = 15;
            btnKatamei.Text = "▶ 型名から検索";
            btnKatamei.UseVisualStyleBackColor = false;
            btnKatamei.Click += btnKatamei_Click;
            // 
            // btnChuban
            // 
            btnChuban.BackColor = Color.SteelBlue;
            btnChuban.FlatStyle = FlatStyle.Flat;
            btnChuban.Font = new Font("メイリオ", 21.75F);
            btnChuban.ForeColor = Color.White;
            btnChuban.Location = new Point(315, 20);
            btnChuban.Margin = new Padding(5);
            btnChuban.Name = "btnChuban";
            btnChuban.Size = new Size(289, 104);
            btnChuban.TabIndex = 14;
            btnChuban.Text = "▶ 注番から検索";
            btnChuban.UseVisualStyleBackColor = false;
            btnChuban.Click += btnChuban_Click;
            // 
            // btnKouban
            // 
            btnKouban.BackColor = Color.SteelBlue;
            btnKouban.FlatStyle = FlatStyle.Flat;
            btnKouban.Font = new Font("メイリオ", 21.75F);
            btnKouban.ForeColor = Color.White;
            btnKouban.Location = new Point(16, 20);
            btnKouban.Margin = new Padding(5);
            btnKouban.Name = "btnKouban";
            btnKouban.Size = new Size(289, 104);
            btnKouban.TabIndex = 13;
            btnKouban.Text = "▶ 工番から検索";
            btnKouban.UseVisualStyleBackColor = false;
            btnKouban.Click += btnKouban_Click;
            // 
            // UcMenuSearch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnPN);
            Controls.Add(btnBN);
            Controls.Add(btnSN);
            Controls.Add(btnKatamei);
            Controls.Add(btnChuban);
            Controls.Add(btnKouban);
            Name = "UcMenuSearch";
            Size = new Size(919, 668);
            ResumeLayout(false);
        }

        #endregion

        private Button btnPN;
        private Button btnBN;
        private Button btnSN;
        private Button btnKatamei;
        private Button btnChuban;
        private Button btnKouban;
    }
}
