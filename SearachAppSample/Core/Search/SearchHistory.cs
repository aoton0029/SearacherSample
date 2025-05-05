using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearachAppSample.Core
{
    /// <summary>
    /// 検索履歴を表すクラス
    /// </summary>
    public class SearchHistory
    {
        public string Category { get; set; }
        public string Query { get; set; }
        public Dictionary<string, object> Parameters { get; set; } = new();
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
