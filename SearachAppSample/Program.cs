using System.Diagnostics;

namespace SearachAppSample
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // ��O�n���h���̐ݒ�
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            // ��DPI�ݒ�
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // �A�v���P�[�V�����f�B���N�g���̊m�F/�쐬
                string appDataPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "SearachAppSample");

                if (!Directory.Exists(appDataPath))
                {
                    Directory.CreateDirectory(appDataPath);
                }

                // �A�v���P�[�V�������s
                Application.Run(new FormMain());
            }
            catch (Exception ex)
            {
                // �v���I�ȃG���[�̏ꍇ
                MessageBox.Show($"�A�v���P�[�V�����N�����ɒv���I�ȃG���[���������܂����B\n{ex.Message}",
                    "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine($"�v���I�ȃG���[: {ex}");
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            // UI�X���b�h�ł̖�������O���n���h��
            Debug.WriteLine($"UI�X���b�h��O: {e.Exception}");
            MessageBox.Show($"�\�����Ȃ��G���[���������܂����B\n{e.Exception.Message}",
                "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // �A�v���P�[�V�����h���C���ł̖�������O���n���h��
            var ex = e.ExceptionObject as Exception;
            Debug.WriteLine($"�������̗�O: {ex}");

            if (e.IsTerminating)
            {
                MessageBox.Show($"�v���I�ȃG���[�������������߃A�v���P�[�V�������I�����܂��B\n{ex?.Message ?? "Unknown error"}",
                    "�v���I�ȃG���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}