using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearachAppSample.Core
{
    /// <summary>
    /// アプリケーション全体の設定
    /// </summary>
    public class GlobalSettings
    {
        public string Theme { get; set; } = "Default";
        public int MaxSearchHistories { get; set; } = 20;
        public List<string> RecentProjects { get; set; } = new();
        public Dictionary<string, object> CustomSettings { get; set; } = new();

        // 追加：色設定
        public ColorSettings Colors { get; set; } = new ColorSettings();

        // 追加：定義済みテーマの名前を取得
        public List<string> AvailableThemes { get; } = new List<string> { "Default", "Dark", "Light", "HighContrast" };

        // 追加：テーマを変更するメソッド
        public void ApplyTheme(string themeName)
        {
            Theme = themeName;

            switch (themeName)
            {
                case "Dark":
                    ApplyDarkTheme();
                    break;
                case "Light":
                    ApplyLightTheme();
                    break;
                case "HighContrast":
                    ApplyHighContrastTheme();
                    break;
                default:
                    // Defaultテーマ（またはカスタム設定の維持）
                    Colors.ResetToDefault();
                    break;
            }
        }

        private void ApplyDarkTheme()
        {
            var colors = Colors;
            colors.PrimaryColor = Color.FromArgb(38, 76, 111); // SteelBlueDarker
            colors.OnPrimaryColor = Color.White;
            colors.PrimaryContainerColor = Color.FromArgb(55, 95, 135);
            colors.OnPrimaryContainerColor = Color.FromArgb(227, 238, 247);
            colors.BackgroundColor = Color.FromArgb(21, 31, 46);
            colors.OnBackgroundColor = Color.FromArgb(220, 230, 240);
            colors.SurfaceColor = Color.FromArgb(30, 41, 56);
            colors.OnSurfaceColor = Color.FromArgb(220, 230, 240);
            colors.SecondaryColor = Color.FromArgb(64, 115, 158);
            colors.OnSecondaryColor = Color.White;
            colors.ErrorColor = Color.FromArgb(207, 102, 121);
            colors.OnErrorColor = Color.White;
            colors.OutlineColor = Color.FromArgb(90, 120, 150);
        }

        private void ApplyLightTheme()
        {
            Colors.ResetToDefault(); // ライトテーマはデフォルトと同じ
        }

        private void ApplyHighContrastTheme()
        {
            var colors = Colors;
            colors.PrimaryColor = Color.Black;
            colors.OnPrimaryColor = Color.White;
            colors.PrimaryContainerColor = Color.FromArgb(30, 30, 30);
            colors.OnPrimaryContainerColor = Color.Yellow;
            colors.BackgroundColor = Color.White;
            colors.OnBackgroundColor = Color.Black;
            colors.SurfaceColor = Color.White;
            colors.OnSurfaceColor = Color.Black;
            colors.SecondaryColor = Color.FromArgb(0, 0, 128); // Navy
            colors.OnSecondaryColor = Color.White;
            colors.ErrorColor = Color.Red;
            colors.OnErrorColor = Color.White;
            colors.OutlineColor = Color.Black;
        }
    }
}
