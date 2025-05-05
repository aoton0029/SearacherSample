using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearachAppSample.Core
{
    /// <summary>
    /// プロジェクト関連の操作を提供するサービスクラス
    /// </summary>
    public class ProjectService
    {
        private readonly AppContext _appContext;

        public ProjectService(AppContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<bool> SaveCurrentProjectAsync()
        {
            var currentProject = _appContext.CurrentProject;
            if (currentProject == null)
                return false;

            try
            {
                await Task.Run(() => currentProject.Save());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Project> CreateProjectAsync(string path, string name)
        {
            // プロジェクトディレクトリの作成
            string projectPath = System.IO.Path.Combine(path, name);
            Directory.CreateDirectory(projectPath);

            var project = new Project(projectPath);

            // 初期設定を適用
            project.UpdateContext(context => {
                context.ProjectVersion = "1.0";
                context.SetSetting("CreatedAt", DateTime.Now);
                context.SetSetting("ProjectName", name);
            });

            await Task.Run(() => project.Save());
            return _appContext.OpenProject(projectPath);
        }

        public List<SearchHistory> GetSearchHistories(string category)
        {
            var currentProject = _appContext.CurrentProject;
            if (currentProject == null)
                return new List<SearchHistory>();

            return currentProject.Context.SearchHistories
                .Where(h => h.Category == category)
                .ToList();
        }

        public void AddSearchHistory(SearchHistory history)
        {
            var currentProject = _appContext.CurrentProject;
            if (currentProject == null)
                return;

            currentProject.UpdateContext(context => {
                // 既存の同一カテゴリの履歴が多すぎる場合は古いものを削除
                var existingHistories = context.SearchHistories
                    .Where(h => h.Category == history.Category)
                    .OrderByDescending(h => h.Timestamp)
                    .Skip(19) // 最新20件を残す
                    .ToList();

                foreach (var oldHistory in existingHistories)
                {
                    context.SearchHistories.Remove(oldHistory);
                }

                context.SearchHistories.Add(history);
            });
        }
    }
}
