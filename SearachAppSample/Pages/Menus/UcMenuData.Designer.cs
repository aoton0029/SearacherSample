namespace SearachAppSample.Pages.Menus
{
    partial class UcMenuData
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
            btnPartsList = new Button();
            btnMacAddress = new Button();
            btnSNList = new Button();
            SuspendLayout();
            // 
            // btnPartsList
            // 
            btnPartsList.BackColor = Color.SteelBlue;
            btnPartsList.FlatStyle = FlatStyle.Flat;
            btnPartsList.Font = new Font("メイリオ", 21.75F);
            btnPartsList.ForeColor = Color.White;
            btnPartsList.Location = new Point(614, 17);
            btnPartsList.Margin = new Padding(5);
            btnPartsList.Name = "btnPartsList";
            btnPartsList.Size = new Size(289, 104);
            btnPartsList.TabIndex = 18;
            btnPartsList.Text = "▶ パーツリスト";
            btnPartsList.UseVisualStyleBackColor = false;
            btnPartsList.Click += btnPartsList_Click;
            // 
            // btnMacAddress
            // 
            btnMacAddress.BackColor = Color.SteelBlue;
            btnMacAddress.FlatStyle = FlatStyle.Flat;
            btnMacAddress.Font = new Font("メイリオ", 21.75F);
            btnMacAddress.ForeColor = Color.White;
            btnMacAddress.Location = new Point(315, 17);
            btnMacAddress.Margin = new Padding(5);
            btnMacAddress.Name = "btnMacAddress";
            btnMacAddress.Size = new Size(289, 104);
            btnMacAddress.TabIndex = 17;
            btnMacAddress.Text = "▶ MACアドレス";
            btnMacAddress.UseVisualStyleBackColor = false;
            btnMacAddress.Click += btnMacAddress_Click;
            // 
            // btnSNList
            // 
            btnSNList.BackColor = Color.SteelBlue;
            btnSNList.FlatStyle = FlatStyle.Flat;
            btnSNList.Font = new Font("メイリオ", 21.75F);
            btnSNList.ForeColor = Color.White;
            btnSNList.Location = new Point(16, 17);
            btnSNList.Margin = new Padding(5);
            btnSNList.Name = "btnSNList";
            btnSNList.Size = new Size(289, 104);
            btnSNList.TabIndex = 16;
            btnSNList.Text = "▶ S/N";
            btnSNList.UseVisualStyleBackColor = false;
            btnSNList.Click += btnSNList_Click;
            // 
            // UcMenuData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnPartsList);
            Controls.Add(btnMacAddress);
            Controls.Add(btnSNList);
            Name = "UcMenuData";
            Size = new Size(919, 668);
            ResumeLayout(false);
        }

        #endregion

        private Button btnPartsList;
        private Button btnMacAddress;
        private Button btnSNList;
    }
}
