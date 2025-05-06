using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearachAppSample.Core
{
    /// <summary>
    /// オブジェクトのスナップショット機能を提供するインターフェース
    /// </summary>
    public interface ISnapshot
    {
        /// <summary>
        /// オブジェクトの現在の状態を複製する
        /// </summary>
        /// <returns>オブジェクトのクローン</returns>
        object Clone();

        /// <summary>
        /// スナップショットの作成時刻
        /// </summary>
        DateTime Timestamp { get; }

        /// <summary>
        /// スナップショットの説明
        /// </summary>
        string Description { get; set; }
    }
}
