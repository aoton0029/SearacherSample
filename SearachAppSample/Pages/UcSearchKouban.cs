using SearachAppSample.Core;
using SearachAppSample.Models.SearchConditions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearachAppSample.Pages
{
    public partial class UcSearchKouban : UserControl, IPage
    {
        private readonly Core.AppContext _appContext;

        public UcSearchKouban(Core.AppContext appContext)
        {
            InitializeComponent();
            _appContext = appContext;
        }

        public void OnPageLeave(NavigationContext context)
        {
            SaveSearchCondition();
        }

        public void OnPageShown(NavigationContext context)
        {
            LoadSearchHistory();
        }

        private void LoadSearchHistory()
        {
            // 検索履歴をロードして表示
            var history = _appContext.SearchResultChuban?.GetHistory();
            // historyを使ってUIを更新...
        }

        private void SaveSearchCondition()
        {
            // 現在の検索条件を保存
            var condition = new SrchCondChuban
            {
                // UIから値を取得...
            };

            if (_appContext.SearchResultChuban != null)
            {
                _appContext.SearchResultChuban.Add(condition);
                _appContext.Save();
            }
        }
    }
}
