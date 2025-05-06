using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearachAppSample.Core
{
    /// <summary>
    /// 検索条件の履歴を管理するクラス
    /// </summary>
    /// <typeparam name="T">履歴に保持するオブジェクトの型</typeparam>
    public class History<T> where T : class, ISnapshot
    {
        private readonly List<T> _history = new();
        private readonly int _maxItems;

        /// <summary>
        /// 履歴に保存できる最大アイテム数
        /// </summary>
        public int MaxItems => _maxItems;

        /// <summary>
        /// 現在の履歴一覧
        /// </summary>
        public IReadOnlyList<T> Items => _history.AsReadOnly();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="maxItems">履歴に保存する最大アイテム数</param>
        public History(int maxItems = 20)
        {
            _maxItems = maxItems > 0 ? maxItems : 20;
        }

        /// <summary>
        /// 履歴に項目を追加する
        /// </summary>
        /// <param name="item">追加する項目</param>
        public void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            // 履歴に追加
            _history.Insert(0, item);

            // 履歴が最大数を超えた場合、古いものから削除
            if (_history.Count > _maxItems)
            {
                _history.RemoveRange(_maxItems, _history.Count - _maxItems);
            }
        }

        /// <summary>
        /// 履歴をクリアする
        /// </summary>
        public void Clear()
        {
            _history.Clear();
        }

        /// <summary>
        /// 指定されたインデックスの履歴項目を取得する
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <returns>履歴項目</returns>
        public T GetItem(int index)
        {
            if (index < 0 || index >= _history.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            return _history[index];
        }

        /// <summary>
        /// 最新の履歴を取得する
        /// </summary>
        /// <returns>最新の履歴、履歴がない場合はnull</returns>
        public T GetLatest()
        {
            return _history.FirstOrDefault();
        }

        /// <summary>
        /// 履歴一覧を取得する
        /// </summary>
        /// <returns>履歴一覧</returns>
        public List<T> GetHistory()
        {
            return _history.ToList();
        }
    }
}
