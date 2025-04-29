using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearachAppSample.Items
{
    public partial class UcItemFilterCheckBoxPanel: UserControl
    {
        private List<CheckBox> _checkBoxes = new List<CheckBox>();
        public event EventHandler FilterChanged;

        // チェックボックスの表示テキストを格納するリスト
        private List<string> _filterOptions = new List<string>();

        [Category("CheckBox")]
        [Description("チェックボックスのテキストリストをカンマ区切りで指定します")]
        [Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<string> FilterOptions
        {
            get { return _filterOptions; }
            set
            {
                _filterOptions = value;
                ApplyFilterOptions();
            }
        }

        [Category("CheckBox")]
        [Editor(typeof(Core.CustomColorEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Color CheckBoxBackColor { get; set; } = SystemColors.Control;
        [Category("CheckBox")]
        [Editor(typeof(Core.CustomColorEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Color CheckBoxForeColor { get; set; } = SystemColors.ControlText;
        [Category("CheckBox")]
        [Editor(typeof(Core.CustomColorEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Color CheckBoxCheckedBackColor { get; set; } = SystemColors.Highlight;
        [Category("CheckBox")]
        [Editor(typeof(Core.CustomColorEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Color CheckBoxCheckedForeColor { get; set; } = SystemColors.HighlightText;
        [Category("CheckBox")]
        public Font CheckBoxFont { get; set; } = SystemFonts.DefaultFont;
        [Category("CheckBox")]
        public FlatStyle CheckBoxFlatStyle { get; set; } = FlatStyle.Standard;
        [Category("CheckBox")]
        public BorderStyle CheckBoxBorderStyle { get; set; } = BorderStyle.None;
        [Category("CheckBox")]
        public Padding CheckBoxPadding { get; set; } = new Padding(5);
        [Category("CheckBox")]
        public Padding CheckBoxMargin { get; set; } = new Padding(5);

        public UcItemFilterCheckBoxPanel()
        {
            InitializeComponent();
        }


        // コントロールのロード時に既存のFilterOptionsを適用
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_filterOptions.Count > 0)
            {
                ApplyFilterOptions();
            }
        }

        // 既存メソッドと互換性を保つために維持
        public void SetFilterOptions(IEnumerable<string> options)
        {
            _filterOptions = new List<string>(options);
            ApplyFilterOptions();
        }

        // FilterOptionsを実際にチェックボックスとして適用するプライベートメソッド
        private void ApplyFilterOptions()
        {
            flowLayoutPanel1.Controls.Clear();
            _checkBoxes.Clear();

            foreach (var option in _filterOptions)
            {
                var checkBox = CreateButtonStyleCheckBox(option);
                _checkBoxes.Add(checkBox);
                flowLayoutPanel1.Controls.Add(checkBox);
            }
        }

        private CheckBox CreateButtonStyleCheckBox(string text)
        {
            var checkBox = new CheckBox
            {
                Appearance = Appearance.Button,
                Text = text,
                AutoSize = true,
                Margin = CheckBoxMargin,
                Padding = CheckBoxPadding,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = CheckBoxBackColor,
                ForeColor = CheckBoxForeColor,
                Font = CheckBoxFont,
                FlatStyle = CheckBoxFlatStyle
            };

            // チェック状態変更時の処理
            checkBox.CheckedChanged += (s, e) =>
            {
                FilterChanged?.Invoke(this, EventArgs.Empty);
                UpdateCheckBoxAppearance(checkBox);
            };

            return checkBox;
        }

        private void UpdateCheckBoxAppearance(CheckBox checkBox)
        {
            // チェック状態によって色を変更
            if (checkBox.Checked)
            {
                checkBox.BackColor = CheckBoxCheckedBackColor;
                checkBox.ForeColor = CheckBoxCheckedForeColor;
            }
            else
            {
                checkBox.BackColor = CheckBoxBackColor;
                checkBox.ForeColor = CheckBoxForeColor;
            }
        }

        // すべてのチェックボックスの外観を更新
        public void UpdateAllCheckBoxesAppearance()
        {
            foreach (var checkBox in _checkBoxes)
            {
                checkBox.Font = CheckBoxFont;
                checkBox.FlatStyle = CheckBoxFlatStyle;
                checkBox.Margin = CheckBoxMargin;
                checkBox.Padding = CheckBoxPadding;
                UpdateCheckBoxAppearance(checkBox);
            }
        }

        public List<string> GetSelectedOptions()
        {
            var selected = new List<string>();
            foreach (var cb in _checkBoxes)
            {
                if (cb.Checked)
                {
                    selected.Add(cb.Text);
                }
            }
            return selected;
        }
    }
}
