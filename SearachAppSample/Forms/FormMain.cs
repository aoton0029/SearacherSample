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

            // �T�[�r�X�v���o�C�_�[�̏�����
            _serviceProvider = new ServiceProvider();

            // ������AppContext�𗘗p����悤�ɕύX
            _appContext = new Core.AppContext(); // �����ŃO���[�o���ݒ肪���[�h�����

            // ��{�T�[�r�X�̓o�^
            _serviceProvider.RegisterSingleton(new EventBus());
            _serviceProvider.RegisterSingleton(_appContext);
            _serviceProvider.RegisterSingleton(new NavigationService(this, _serviceProvider));
            _serviceProvider.RegisterSingleton(new UcPageMain(_serviceProvider));

            // �I�����ɐݒ��ۑ����邽�߂ɁAFormClosing�C�x���g���n���h��
            this.FormClosing += FormMain_FormClosing;

            // �e�[�}�̓K�p
            ApplyTheme();
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            try
            {
                // �A�v���P�[�V�����N�����̏���
                LoadRecentProjectsMenu();

                // ���C���y�[�W�ւ̃i�r�Q�[�V����
                _serviceProvider.Resolve<NavigationService>().NavigateTo<UcPageMain>();

                // AppContext�̃C�x���g���Ď�
                _appContext.ProjectOpened += AppContext_ProjectOpened;
                _appContext.ProjectClosed += AppContext_ProjectClosed;

                // �����ŋ߂̃v���W�F�N�g������΁A�Ō�ɊJ�����v���W�F�N�g�������ŊJ��
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
                            // �v���W�F�N�g���J���Ȃ��ꍇ�̓G���[��\��
                            MessageBox.Show($"�ŋߎg�p�����v���W�F�N�g���J���܂���ł����B\n{ex.Message}",
                                "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // �N�����̗�O���n���h��
                MessageBox.Show($"�A�v���P�[�V�����N�����ɃG���[���������܂����B\n{ex.Message}",
                    "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine($"�N���G���[: {ex}");
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // ���݊J���Ă���v���W�F�N�g�̕ۑ�
                if (_appContext.CurrentProject != null)
                {
                    _appContext.CurrentProject.Save();
                }

                // �A�v���P�[�V�����ݒ�̕ۑ�
                _appContext.SaveSettings();
            }
            catch (Exception ex)
            {
                // �I�����̃G���[�����O�Ɏc��
                Debug.WriteLine($"�I�����G���[: {ex}");
            }
        }

        #region �v���W�F�N�g�Ǘ�

        private void AppContext_ProjectOpened(object sender, Project project)
        {
            // �v���W�F�N�g���J���ꂽ���̏���
            this.Text = $"SearachAppSample - {project.Name}";

            // �ŋߎg�p�����v���W�F�N�g���X�g�̍X�V
            UpdateRecentProjects(project.Path);

            // �K�v�ɉ�����UI���X�V
            RefreshUI();
        }

        private void AppContext_ProjectClosed(object sender, Project project)
        {
            // �v���W�F�N�g������ꂽ���̏���
            if (_appContext.CurrentProject == null)
            {
                this.Text = "SearachAppSample";
            }
            else
            {
                this.Text = $"SearachAppSample - {_appContext.CurrentProject.Name}";
            }

            // �K�v�ɉ�����UI���X�V
            RefreshUI();
        }

        private void UpdateRecentProjects(string projectPath)
        {
            // �ŋߎg�p�����v���W�F�N�g���X�g����A�����p�X������΍폜
            _appContext.Settings.RecentProjects.Remove(projectPath);

            // ���X�g�̐擪�ɒǉ�
            _appContext.Settings.RecentProjects.Insert(0, projectPath);

            // �ő�10���ɐ���
            if (_appContext.Settings.RecentProjects.Count > 10)
            {
                _appContext.Settings.RecentProjects =
                    _appContext.Settings.RecentProjects.Take(10).ToList();
            }

            // ���j���[�̍X�V
            LoadRecentProjectsMenu();
        }

        private void LoadRecentProjectsMenu()
        {
            // NOTE: �����ł̓��j���[�̎����͊ȗ������Ă��܂����A
            // ���ۂɂ�MenuStrip�Ȃǂ��g���Ď�������K�v������܂�
            // ���̕����́A�f�U�C�i�[�Œǉ�����MenuStrip�ɑΉ�����R�[�h���C�����Ă�������
        }

        #endregion

        #region �e�[�}��UI

        private void ApplyTheme()
        {
            // �e�[�}�ɉ�����UI��ύX
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
            // ���݂̃v���W�F�N�g�̏�Ԃɉ�����UI���X�V
            bool hasProject = _appContext.CurrentProject != null;

            // �e�탁�j���[��c�[���o�[�̗L��/������Ԃ�ύX
            // ��: menuSaveProject.Enabled = hasProject;
        }

        #endregion

        #region ���j���[�C�x���g

        // �V�K�v���W�F�N�g�쐬�R�}���h
        private void CreateNewProject()
        {
            // �t�H���_�I���_�C�A���O
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "�V�����v���W�F�N�g���쐬����t�H���_��I�����Ă�������";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    // �v���W�F�N�g�����̓_�C�A���O��\��
                    string projectName = "NewProject"; // ���ۂɂ͓��̓_�C�A���O�Ŏ擾

                    try
                    {
                        // ���[�f�B���O�\���t���Ńv���W�F�N�g�쐬
                        var projectService = _appContext.GetService<ProjectService>();
                        Common.RunWithLoadingForm("�v���W�F�N�g���쐬���Ă��܂�...", false, async (token) =>
                        {
                            await projectService.CreateProjectAsync(folderDialog.SelectedPath, projectName);
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"�v���W�F�N�g�쐬���ɃG���[���������܂����B\n{ex.Message}",
                            "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // �v���W�F�N�g���J���R�}���h
        private void OpenProject()
        {
            // �t�H���_�I���_�C�A���O
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "�J���v���W�F�N�g�̃t�H���_��I�����Ă�������";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // �v���W�F�N�g���J��
                        _appContext.OpenProject(folderDialog.SelectedPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"�v���W�F�N�g���J���ۂɃG���[���������܂����B\n{ex.Message}",
                            "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // �ݒ��ʂ��J���R�}���h
        private void OpenSettings()
        {
            // �ݒ��ʂ̃_�C�A���O��\�����鏈��
            // ����͎��ۂ̎����ɍ��킹�ďC�����Ă�������
            MessageBox.Show("�ݒ��ʁi�������j");
        }

        #endregion
    }
}
