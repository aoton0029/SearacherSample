using SearachAppSample.Models.SearchConditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SearachAppSample.Core
{
    /// <summary>
    /// アプリケーション全体のコンテキストを管理するクラス
    /// </summary>
    public class AppContext
    {
        private readonly string _appDataPath;
        private readonly List<Project> _projects = new();
        private readonly ServiceProvider _serviceProvider = new();

        public event EventHandler<Project> ProjectOpened;
        public event EventHandler<Project> ProjectClosed;

        public IReadOnlyList<Project> Projects => _projects.AsReadOnly();
        public GlobalSettings Settings { get; private set; }
        public Project CurrentProject { get; private set; }

        public History<SrchCondKouban> SearchResultKouban { get; set; }
        public History<SrchCondBN> SearchResultBN { get; set; }
        public History<SrchCondChuban> SearchResultChuban { get; set; }
        public History<SrchCondKatamei> SearchResultKatamei { get; set; }
        public History<SrchCondPN> SearchResultPN { get; set; }
        public History<SrchCondSN> SearchResultSN { get; set; }
        public UserRank UserRank { get; set; } = UserRank.Standard;

        public AppSettings AppSettings { get; set; } = new AppSettings();

        public AppContext()
        {
            _appDataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "SearachAppSample");

            Directory.CreateDirectory(_appDataPath);
            LoadSettings();

            // 履歴オブジェクトの初期化
            int maxHistories = Settings.MaxSearchHistories;
            SearchResultKouban = new History<SrchCondKouban>(maxHistories);
            SearchResultBN = new History<SrchCondBN>(maxHistories);
            SearchResultChuban = new History<SrchCondChuban>(maxHistories);
            SearchResultKatamei = new History<SrchCondKatamei>(maxHistories);
            SearchResultPN = new History<SrchCondPN>(maxHistories);
            SearchResultSN = new History<SrchCondSN>(maxHistories);

            // 基本サービスの登録
            _serviceProvider.RegisterSingleton(this);
            _serviceProvider.RegisterSingleton<ProjectService>();
        }


        public void LoadSettings()
        {
            var configManager = new ConfigurationManager<GlobalSettings>("global_settings.json");
            Settings = configManager.LoadConfiguration();
        }

        public void SaveSettings()
        {
            var configManager = new ConfigurationManager<GlobalSettings>("global_settings.json");
            configManager.SaveConfiguration(Settings);
        }

        public Project OpenProject(string path)
        {
            // 既に開いている場合は既存のインスタンスを返す
            var existingProject = _projects.FirstOrDefault(p => p.Path == path);
            if (existingProject != null)
            {
                CurrentProject = existingProject;
                return existingProject;
            }

            // 新しいプロジェクトを作成
            var project = new Project(path);
            project.Load();

            _projects.Add(project);
            CurrentProject = project;

            ProjectOpened?.Invoke(this, project);
            return project;
        }

        public void CloseProject(Project project)
        {
            if (_projects.Contains(project))
            {
                project.Save();
                _projects.Remove(project);

                ProjectClosed?.Invoke(this, project);

                // 現在のプロジェクトが閉じられた場合、別のプロジェクトを選択
                if (CurrentProject == project)
                {
                    CurrentProject = _projects.FirstOrDefault();
                }
            }
        }

        public T GetService<T>() where T : class
        {
            return _serviceProvider.Resolve<T>();
        }
    }

    public enum UserRank
    {
        Guest,
        Standard,
        Premium,
        Admin
    }
}
