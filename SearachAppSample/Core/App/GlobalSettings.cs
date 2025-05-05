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
        public string Theme { get; set; } = "Light";
        public int MaxSearchHistories { get; set; } = 20;
        public List<string> RecentProjects { get; set; } = new();
        public Dictionary<string, object> CustomSettings { get; set; } = new();
    }
}
