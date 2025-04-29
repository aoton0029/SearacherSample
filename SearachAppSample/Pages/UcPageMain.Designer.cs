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
            ucItemHeader2 = new SearachAppSample.Items.UcItemHeader();
            btnSearch = new Button();
            btnData = new Button();
            button3 = new Button();
            pnlMenu = new Panel();
            btnSetting = new Button();
            SuspendLayout();
            // 
            // ucItemHeader2
            // 
            ucItemHeader2.BackColor = Color.FromArgb(43, 79, 107);
            ucItemHeader2.Dock = DockStyle.Top;
            ucItemHeader2.Location = new Point(0, 0);
            ucItemHeader2.Name = "ucItemHeader2";
            ucItemHeader2.Size = new Size(1350, 33);
            ucItemHeader2.TabIndex = 13;
            ucItemHeader2.Title = "検索";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.SteelBlue;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("メイリオ", 27.75F);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(44, 72);
            btnSearch.Margin = new Padding(6);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(306, 158);
            btnSearch.TabIndex = 14;
            btnSearch.Text = "▶ 検索";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnData
            // 
            btnData.BackColor = Color.SteelBlue;
            btnData.FlatStyle = FlatStyle.Flat;
            btnData.Font = new Font("メイリオ", 27.75F);
            btnData.ForeColor = Color.White;
            btnData.Location = new Point(44, 242);
            btnData.Margin = new Padding(6);
            btnData.Name = "btnData";
            btnData.Size = new Size(306, 158);
            btnData.TabIndex = 15;
            btnData.Text = "▶ データ";
            btnData.UseVisualStyleBackColor = false;
            btnData.Click += btnData_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.SteelBlue;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("メイリオ", 27.75F);
            button3.ForeColor = Color.White;
            button3.Location = new Point(44, 412);
            button3.Margin = new Padding(6);
            button3.Name = "button3";
            button3.Size = new Size(306, 158);
            button3.TabIndex = 16;
            button3.Text = "▶ ";
            button3.UseVisualStyleBackColor = false;
            // 
            // pnlMenu
            // 
            pnlMenu.Location = new Point(369, 72);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(919, 668);
            pnlMenu.TabIndex = 17;
            // 
            // btnSetting
            // 
            btnSetting.BackColor = Color.SteelBlue;
            btnSetting.FlatStyle = FlatStyle.Flat;
            btnSetting.Font = new Font("メイリオ", 27.75F);
            btnSetting.ForeColor = Color.White;
            btnSetting.Location = new Point(44, 582);
            btnSetting.Margin = new Padding(6);
            btnSetting.Name = "btnSetting";
            btnSetting.Size = new Size(306, 158);
            btnSetting.TabIndex = 18;
            btnSetting.Text = "▶ 設定";
            btnSetting.UseVisualStyleBackColor = false;
            // 
            // UcPageMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnSetting);
            Controls.Add(pnlMenu);
            Controls.Add(button3);
            Controls.Add(btnData);
            Controls.Add(btnSearch);
            Controls.Add(ucItemHeader2);
            Name = "UcPageMain";
            Size = new Size(1350, 780);
            ResumeLayout(false);
        }

        #endregion
        private Items.UcItemHeader ucItemHeader1;
        private Items.UcItemHeader ucItemHeader2;
        private Button btnSearch;
        private Button btnData;
        private Button button3;
        private Panel pnlMenu;
        private Button btnSetting;
    }
}
