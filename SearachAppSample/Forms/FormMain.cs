using SearachAppSample.Core;
using SearachAppSample.Pages;
using System.Diagnostics;

namespace SearachAppSample
{
    public partial class FormMain : Form
    {
        private readonly ServiceProvider _serviceProvider;
        private readonly Core.AppContext _appContext;

        public FormMain()
        {
            InitializeComponent();

            // サービスプロバイダーの初期化
            _serviceProvider = new ServiceProvider();

            // 既存のAppContextを利用するように変更
            _appContext = new Core.AppContext(); // ここでグローバル設定がロードされる

            // 基本サービスの登録
            _serviceProvider.RegisterSingleton(new EventBus());
            _serviceProvider.RegisterSingleton(_appContext);
            _serviceProvider.RegisterSingleton(new NavigationService(this, _serviceProvider));
            _serviceProvider.RegisterSingleton(new UcPageMain(_serviceProvider));

            // 終了時に設定を保存するために、FormClosingイベントをハンドル
            this.FormClosing += FormMain_FormClosing;

            // テーマの適用
            ApplyTheme();
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            try
            {
                // アプリケーション起動時の処理
                LoadRecentProjectsMenu();

                // メインページへのナビゲーション
                _serviceProvider.Resolve<NavigationService>().NavigateTo<UcPageMain>();

                // AppContextのイベントを監視
                _appContext.ProjectOpened += AppContext_ProjectOpened;
                _appContext.ProjectClosed += AppContext_ProjectClosed;

                // もし最近のプロジェクトがあれば、最後に開いたプロジェクトを自動で開く
                if (_appContext.Settings.RecentProjects.Count > 0)
                {
                    string lastProject = _appContext.Settings.RecentProjects.First();
                    if (Directory.Exists(lastProject))
                    {
                        try
                        {
                            _appContext.OpenProject(lastProject);
                        }
                        catch (Exception ex)
                        {
                            // プロジェクトが開けない場合はエラーを表示
                            MessageBox.Show($"最近使用したプロジェクトを開けませんでした。\n{ex.Message}",
                                "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 起動時の例外をハンドル
                MessageBox.Show($"アプリケーション起動中にエラーが発生しました。\n{ex.Message}",
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine($"起動エラー: {ex}");
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // 現在開いているプロジェクトの保存
                if (_appContext.CurrentProject != null)
                {
                    _appContext.CurrentProject.Save();
                }

                // アプリケーション設定の保存
                _appContext.SaveSettings();
            }
            catch (Exception ex)
            {
                // 終了時のエラーをログに残す
                Debug.WriteLine($"終了時エラー: {ex}");
            }
        }

        #region プロジェクト管理

        private void AppContext_ProjectOpened(object sender, Project project)
        {
            // プロジェクトが開かれた時の処理
            this.Text = $"SearachAppSample - {project.Name}";

            // 最近使用したプロジェクトリストの更新
            UpdateRecentProjects(project.Path);

            // 必要に応じてUIを更新
            RefreshUI();
        }

        private void AppContext_ProjectClosed(object sender, Project project)
        {
            // プロジェクトが閉じられた時の処理
            if (_appContext.CurrentProject == null)
            {
                this.Text = "SearachAppSample";
            }
            else
            {
                this.Text = $"SearachAppSample - {_appContext.CurrentProject.Name}";
            }

            // 必要に応じてUIを更新
            RefreshUI();
        }

        private void UpdateRecentProjects(string projectPath)
        {
            // 最近使用したプロジェクトリストから、同じパスがあれば削除
            _appContext.Settings.RecentProjects.Remove(projectPath);

            // リストの先頭に追加
            _appContext.Settings.RecentProjects.Insert(0, projectPath);

            // 最大10件に制限
            if (_appContext.Settings.RecentProjects.Count > 10)
            {
                _appContext.Settings.RecentProjects =
                    _appContext.Settings.RecentProjects.Take(10).ToList();
            }

            // メニューの更新
            LoadRecentProjectsMenu();
        }

        private void LoadRecentProjectsMenu()
        {
            // NOTE: ここではメニューの実装は簡略化していますが、
            // 実際にはMenuStripなどを使って実装する必要があります
            // この部分は、デザイナーで追加したMenuStripに対応するコードを修正してください
        }

        #endregion

        #region テーマとUI

        private void ApplyTheme()
        {
            // テーマに応じてUIを変更
            if (_appContext.Settings.Theme == "Dark")
            {
                this.BackColor = ColorUtility.SteelBlueDarkest;
                this.ForeColor = Color.White;
            }
            else // Light Theme
            {
                this.BackColor = ColorUtility.SteelBlueLightest;
                this.ForeColor = Color.Black;
            }
        }

        private void RefreshUI()
        {
            // 現在のプロジェクトの状態に応じてUIを更新
            bool hasProject = _appContext.CurrentProject != null;

            // 各種メニューやツールバーの有効/無効状態を変更
            // 例: menuSaveProject.Enabled = hasProject;
        }

        #endregion

        #region メニューイベント

        // 新規プロジェクト作成コマンド
        private void CreateNewProject()
        {
            // フォルダ選択ダイアログ
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "新しいプロジェクトを作成するフォルダを選択してください";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    // プロジェクト名入力ダイアログを表示
                    string projectName = "NewProject"; // 実際には入力ダイアログで取得

                    try
                    {
                        // ローディング表示付きでプロジェクト作成
                        var projectService = _appContext.GetService<ProjectService>();
                        Common.RunWithLoadingForm("プロジェクトを作成しています...", false, async (token) =>
                        {
                            await projectService.CreateProjectAsync(folderDialog.SelectedPath, projectName);
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"プロジェクト作成中にエラーが発生しました。\n{ex.Message}",
                            "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // プロジェクトを開くコマンド
        private void OpenProject()
        {
            // フォルダ選択ダイアログ
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "開くプロジェクトのフォルダを選択してください";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // プロジェクトを開く
                        _appContext.OpenProject(folderDialog.SelectedPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"プロジェクトを開く際にエラーが発生しました。\n{ex.Message}",
                            "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // 設定画面を開くコマンド
        private void OpenSettings()
        {
            // 設定画面のダイアログを表示する処理
            // これは実際の実装に合わせて修正してください
            MessageBox.Show("設定画面（未実装）");
        }

        #endregion
    }
}
