using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace SearachAppSample.Core
{
    internal class ColorUtility
    {
        /*
        | トーン | 色名 | Hex | RGB |
       |:------|:---|:---|:---|
       | Lightest | SteelBlue50 | #e3eef7 | (227, 238, 247) |
       | Lighter | SteelBlue100 | #c0d6ec | (192, 214, 236) |
       | Light | SteelBlue200 | #9dbfe2 | (157, 191, 226) |
       | Base (Primary) | SteelBlue500 | #4682b4 | (70, 130, 180) |
       | Dark | SteelBlue700 | #2e5d85 | (46, 93, 133) |
       | Darker | SteelBlue800 | #264c6f | (38, 76, 111) |
       | Darkest | SteelBlue900 | #1f3d59 | (31, 61, 89) |

       | Role | Hex | 説明 |
       |:--|:--|:--|
       | Primary | #4682B4 | 基本のSteelBlue |
       | OnPrimary | #FFFFFF | Primary上のテキスト色（白） |
       | PrimaryContainer | #C9DDF0 | Primaryを薄めたコンテナ色 |
       | OnPrimaryContainer | #0E2A41 | PrimaryContainer上のテキスト色（深い青） |
       | Secondary | #5B9BD5 | Primaryをやや明るくした青 | 
       | OnSecondary | #FFFFFF | Secondary上のテキスト色 | 
       | SecondaryContainer | #D6E6F5 | Secondaryをさらに薄めた背景色 | 
       | OnSecondaryContainer | #1A3C5A | SecondaryContainer上のテキスト色 |
       | Tertiary | #7AA4C9 | 少しグレイッシュなSteelBlue系 | 
       | OnTertiary | #FFFFFF | Tertiary上のテキスト色 | 
       | TertiaryContainer | #DDE9F5 | Tertiaryをさらに明るく | 
       | OnTertiaryContainer | #23384D | TertiaryContainer上のテキスト色 |
       | Background | #F7FAFD | ごく淡い水色の背景 | 
       | OnBackground | #1E2E3E | 背景上のテキスト色 |
       | Surface | #F2F7FB | 背景より少し沈んだ面色 | 
       | OnSurface | #1E2E3E | Surface上のテキスト色 |
       | Outline | #8CAAC5 | 枠線・区切り線用（SteelBlueを薄めた） |
       | Error | #B3261E | 通常のMaterial Errorカラー | 
       | OnError | #FFFFFF | Error上のテキスト色 | 
       | ErrorContainer | #F9DEDC | エラー用背景色 | 
       | OnErrorContainer | #410E0B | Error背景上のテキスト色 |
        */

        public static readonly Color SteelBlueLightest = Color.FromArgb(227, 238, 247);
        public static readonly Color SteelBlueLighter = Color.FromArgb(192, 214, 236);
        public static readonly Color SteelBlueLight = Color.FromArgb(157, 191, 226);
        public static readonly Color SteelBlueBase = Color.FromArgb(70, 130, 180);
        public static readonly Color SteelBlueDark = Color.FromArgb(46, 93, 133);
        public static readonly Color SteelBlueDarker = Color.FromArgb(38, 76, 111);
        public static readonly Color SteelBlueDarkest = Color.FromArgb(31, 61, 89);

        // ダークテーマのカラーパレット
        public static readonly Color[] DarkThemeColors = new Color[]
        {
            Color.FromArgb(21, 31, 46),      // 背景色
            Color.FromArgb(30, 41, 56),      // サーフェス色
            Color.FromArgb(38, 76, 111),     // プライマリ色
            Color.FromArgb(55, 95, 135),     // プライマリコンテナ色
            Color.FromArgb(64, 115, 158),    // セカンダリ色
            Color.FromArgb(227, 238, 247),   // 明るいテキスト色
            Color.FromArgb(220, 230, 240),   // 標準テキスト色
            Color.FromArgb(90, 120, 150),    // アウトライン色
            Color.FromArgb(207, 102, 121),   // エラー色
            Color.FromArgb(45, 57, 75),      // 濃いサーフェス色
            Color.FromArgb(53, 85, 115),     // アクセント色1
            Color.FromArgb(75, 115, 155)     // アクセント色2
        };

        // ライトテーマのカラーパレット
        public static readonly Color[] LightThemeColors = new Color[]
        {
            Color.FromArgb(247, 250, 253),   // 背景色
            Color.FromArgb(242, 247, 251),   // サーフェス色
            Color.FromArgb(70, 130, 180),    // プライマリ色
            Color.FromArgb(201, 221, 240),   // プライマリコンテナ色
            Color.FromArgb(91, 155, 213),    // セカンダリ色
            Color.FromArgb(14, 42, 65),      // 濃いテキスト色
            Color.FromArgb(30, 46, 62),      // 標準テキスト色
            Color.FromArgb(140, 170, 197),   // アウトライン色
            Color.FromArgb(179, 38, 30),     // エラー色
            Color.FromArgb(227, 238, 247),   // 明るいサーフェス色
            Color.FromArgb(157, 191, 226),   // アクセント色1
            Color.FromArgb(192, 214, 236)    // アクセント色2
        };

        // ハイコントラストテーマのカラーパレット
        public static readonly Color[] HighContrastThemeColors = new Color[]
        {
            Color.White,                     // 背景色
            Color.FromArgb(245, 245, 245),   // サーフェス色
            Color.Black,                     // プライマリ色
            Color.FromArgb(30, 30, 30),      // プライマリコンテナ色
            Color.FromArgb(0, 0, 128),       // セカンダリ色 (Navy)
            Color.Yellow,                    // 強調テキスト色
            Color.Black,                     // 標準テキスト色
            Color.Black,                     // アウトライン色
            Color.Red,                       // エラー色
            Color.FromArgb(225, 225, 225),   // 明るいサーフェス色
            Color.FromArgb(0, 0, 160),       // アクセント色1
            Color.FromArgb(0, 100, 0)        // アクセント色2
        };
    }


    /// <summary>
    /// テーマカラーを表すクラス
    /// </summary>
    public class ThemeColor
    {
        public Color Color { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ThemeColor(Color color, string name, string description = "")
        {
            Color = color;
            Name = name;
            Description = description;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    /// <summary>
    /// テーマカラー選択のためのカスタムエディタ
    /// </summary>
    public class ThemeColorEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            if (editorService != null)
            {
                ThemeColorPicker picker = new ThemeColorPicker(value as Color?);

                editorService.DropDownControl(picker);

                if (picker.SelectedColor.HasValue)
                {
                    return picker.SelectedColor.Value;
                }
            }

            return value;
        }
    }

    /// <summary>
    /// テーマカラーを選択するためのピッカーコントロール
    /// </summary>
    public class ThemeColorPicker : UserControl
    {
        private Color? _selectedColor;
        public Color? SelectedColor
        {
            get => _selectedColor;
            private set => _selectedColor = value;
        }

        private const int ColorItemSize = 24;
        private const int ColorItemMargin = 2;
        private const int Padding = 8;
        private int _colorsPerRow = 6;

        private readonly List<ThemeColor> _lightThemeColors = new List<ThemeColor>();
        private readonly List<ThemeColor> _darkThemeColors = new List<ThemeColor>();
        private readonly List<ThemeColor> _accentColors = new List<ThemeColor>();

        public ThemeColorPicker(Color? initialColor)
        {
            _selectedColor = initialColor;
            InitializeComponent();
            PopulateThemeColors();
            Size = new Size((_colorsPerRow * (ColorItemSize + ColorItemMargin * 2)) + Padding * 2, 400);
        }

        private void InitializeComponent()
        {
            AutoScroll = true;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            //Padding = new Padding(Padding);

            Paint += ThemeColorPicker_Paint;
            MouseClick += ThemeColorPicker_MouseClick;
        }

        private void PopulateThemeColors()
        {
            // ライトテーマカラー
            _lightThemeColors.Add(new ThemeColor(ColorUtility.LightThemeColors[0], "背景色", "ライトテーマ背景色"));
            _lightThemeColors.Add(new ThemeColor(ColorUtility.LightThemeColors[1], "サーフェス色", "ライトテーマサーフェス色"));
            _lightThemeColors.Add(new ThemeColor(ColorUtility.LightThemeColors[2], "プライマリ色", "ライトテーマプライマリ色"));
            _lightThemeColors.Add(new ThemeColor(ColorUtility.LightThemeColors[3], "プライマリコンテナ色", "ライトテーマプライマリコンテナ色"));
            _lightThemeColors.Add(new ThemeColor(ColorUtility.LightThemeColors[4], "セカンダリ色", "ライトテーマセカンダリ色"));
            _lightThemeColors.Add(new ThemeColor(ColorUtility.LightThemeColors[5], "濃いテキスト色", "ライトテーマ濃いテキスト色"));
            _lightThemeColors.Add(new ThemeColor(ColorUtility.LightThemeColors[6], "標準テキスト色", "ライトテーマ標準テキスト色"));
            _lightThemeColors.Add(new ThemeColor(ColorUtility.LightThemeColors[7], "アウトライン色", "ライトテーマアウトライン色"));
            _lightThemeColors.Add(new ThemeColor(ColorUtility.LightThemeColors[8], "エラー色", "ライトテーマエラー色"));
            _lightThemeColors.Add(new ThemeColor(ColorUtility.LightThemeColors[9], "明るいサーフェス色", "ライトテーマ明るいサーフェス色"));

            // ダークテーマカラー
            _darkThemeColors.Add(new ThemeColor(ColorUtility.DarkThemeColors[0], "背景色", "ダークテーマ背景色"));
            _darkThemeColors.Add(new ThemeColor(ColorUtility.DarkThemeColors[1], "サーフェス色", "ダークテーマサーフェス色"));
            _darkThemeColors.Add(new ThemeColor(ColorUtility.DarkThemeColors[2], "プライマリ色", "ダークテーマプライマリ色"));
            _darkThemeColors.Add(new ThemeColor(ColorUtility.DarkThemeColors[3], "プライマリコンテナ色", "ダークテーマプライマリコンテナ色"));
            _darkThemeColors.Add(new ThemeColor(ColorUtility.DarkThemeColors[4], "セカンダリ色", "ダークテーマセカンダリ色"));
            _darkThemeColors.Add(new ThemeColor(ColorUtility.DarkThemeColors[5], "明るいテキスト色", "ダークテーマ明るいテキスト色"));
            _darkThemeColors.Add(new ThemeColor(ColorUtility.DarkThemeColors[6], "標準テキスト色", "ダークテーマ標準テキスト色"));
            _darkThemeColors.Add(new ThemeColor(ColorUtility.DarkThemeColors[7], "アウトライン色", "ダークテーマアウトライン色"));
            _darkThemeColors.Add(new ThemeColor(ColorUtility.DarkThemeColors[8], "エラー色", "ダークテーマエラー色"));
            _darkThemeColors.Add(new ThemeColor(ColorUtility.DarkThemeColors[9], "濃いサーフェス色", "ダークテーマ濃いサーフェス色"));

            // アクセントカラー
            _accentColors.Add(new ThemeColor(ColorUtility.SteelBlueLightest, "SteelBlue最明色", "SteelBlueLightest"));
            _accentColors.Add(new ThemeColor(ColorUtility.SteelBlueLighter, "SteelBlueより明るい色", "SteelBlueLighter"));
            _accentColors.Add(new ThemeColor(ColorUtility.SteelBlueLight, "SteelBlue明色", "SteelBlueLight"));
            _accentColors.Add(new ThemeColor(ColorUtility.SteelBlueBase, "SteelBlue基本色", "SteelBlueBase"));
            _accentColors.Add(new ThemeColor(ColorUtility.SteelBlueDark, "SteelBlue暗色", "SteelBlueDark"));
            _accentColors.Add(new ThemeColor(ColorUtility.SteelBlueDarker, "SteelBlueより暗い色", "SteelBlueDarker"));
            _accentColors.Add(new ThemeColor(ColorUtility.SteelBlueDarkest, "SteelBlue最暗色", "SteelBlueDarkest"));
        }

        private void ThemeColorPicker_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Font titleFont = new Font(Font.FontFamily, 9, FontStyle.Bold);
            Font normalFont = new Font(Font.FontFamily, 8);

            int y = Padding;

            // ライトテーマカラーを描画
            g.DrawString("ライトテーマカラー", titleFont, Brushes.Black, Padding, y);
            y += 20;
            DrawColorSection(g, _lightThemeColors, ref y);

            y += 10;
            g.DrawString("ダークテーマカラー", titleFont, Brushes.Black, Padding, y);
            y += 20;
            DrawColorSection(g, _darkThemeColors, ref y);

            y += 10;
            g.DrawString("アクセントカラー", titleFont, Brushes.Black, Padding, y);
            y += 20;
            DrawColorSection(g, _accentColors, ref y);
        }

        private void DrawColorSection(Graphics g, List<ThemeColor> colors, ref int y)
        {
            int x = Padding;
            int count = 0;

            foreach (var themeColor in colors)
            {
                Rectangle colorRect = new Rectangle(
                    x,
                    y,
                    ColorItemSize,
                    ColorItemSize);

                // 色を描画
                using (SolidBrush brush = new SolidBrush(themeColor.Color))
                {
                    g.FillRectangle(brush, colorRect);
                }

                // 枠線を描画
                g.DrawRectangle(Pens.Gray, colorRect);

                // 選択されている色の場合、強調表示
                if (_selectedColor.HasValue && themeColor.Color == _selectedColor.Value)
                {
                    Rectangle selectedRect = new Rectangle(
                        colorRect.X - 2,
                        colorRect.Y - 2,
                        colorRect.Width + 4,
                        colorRect.Height + 4);

                    g.DrawRectangle(new Pen(Color.Black, 2), selectedRect);
                }

                count++;
                x += ColorItemSize + ColorItemMargin * 2;

                if (count % _colorsPerRow == 0)
                {
                    x = Padding;
                    y += ColorItemSize + ColorItemMargin * 2 + 12; // 名前用の余白を追加
                }
            }

            if (count % _colorsPerRow != 0)
            {
                y += ColorItemSize + ColorItemMargin * 2 + 12;
            }
        }

        private void ThemeColorPicker_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X - Padding;
            int y = e.Y;

            // 各セクションの高さを計算
            int lightThemeHeaderHeight = 20;
            int lightThemeRowCount = (int)Math.Ceiling(_lightThemeColors.Count / (double)_colorsPerRow);
            int lightThemeHeight = lightThemeHeaderHeight + lightThemeRowCount * (ColorItemSize + ColorItemMargin * 2 + 12);

            int darkThemeHeaderHeight = 20;
            int darkThemeRowCount = (int)Math.Ceiling(_darkThemeColors.Count / (double)_colorsPerRow);
            int darkThemeHeight = darkThemeHeaderHeight + darkThemeRowCount * (ColorItemSize + ColorItemMargin * 2 + 12);

            List<ThemeColor> targetSection;
            int startY;

            // クリックされたセクションを特定
            if (y < lightThemeHeight)
            {
                targetSection = _lightThemeColors;
                startY = lightThemeHeaderHeight + Padding;
            }
            else if (y < lightThemeHeight + 10 + darkThemeHeight)
            {
                targetSection = _darkThemeColors;
                startY = lightThemeHeight + 10 + darkThemeHeaderHeight + Padding;
            }
            else
            {
                targetSection = _accentColors;
                startY = lightThemeHeight + 10 + darkThemeHeight + 10 + 20 + Padding;
            }

            // クリックされた位置の色を特定
            y -= startY;
            int row = y / (ColorItemSize + ColorItemMargin * 2 + 12);
            int col = x / (ColorItemSize + ColorItemMargin * 2);

            int index = row * _colorsPerRow + col;

            if (index >= 0 && index < targetSection.Count)
            {
                SelectedColor = targetSection[index].Color;
                Invalidate(); // 再描画して選択を表示
            }
        }
    }

}
