using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearachAppSample
{
    /// <summary>
    /// データエクスポート機能を提供するインターフェース
    /// </summary>
    public interface IExport
    {
        /// <summary>
        /// データをエクスポートする
        /// </summary>
        /// <param name="filePath">エクスポート先のファイルパス</param>
        /// <returns>エクスポートが成功したかどうか</returns>
        Task<bool> ExportAsync(string filePath);

        /// <summary>
        /// ストリームにデータをエクスポートする
        /// </summary>
        /// <param name="stream">エクスポート先のストリーム</param>
        /// <returns>エクスポートが成功したかどうか</returns>
        Task<bool> ExportToStreamAsync(Stream stream);

        /// <summary>
        /// エクスポート対象の名前を取得する
        /// </summary>
        string Name { get; }
    }
}
