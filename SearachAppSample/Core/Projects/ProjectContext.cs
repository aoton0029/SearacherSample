using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearachAppSample.Core
{
    /// <summary>
    /// プロジェクト固有のコンテキスト情報を格納するクラス
    /// </summary>
    public class ProjectContext
    {
        public string ProjectVersion { get; set; } = "1.0";
        public Dictionary<string, object> Settings { get; set; } = new();
        public Dictionary<string, List<string>> AutoCompleteSuggestions { get; set; } = new();

        // プロジェクト特有の設定値を取得・設定するヘルパーメソッド
        public T GetSetting<T>(string key, T defaultValue = default)
        {
            if (Settings.TryGetValue(key, out var value) && value is T typedValue)
            {
                return typedValue;
            }
            return defaultValue;
        }

        public void SetSetting<T>(string key, T value)
        {
            Settings[key] = value;
        }
    }
}
