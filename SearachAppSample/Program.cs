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
            // 例外ハンドラの設定
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            // 高DPI設定
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // アプリケーションディレクトリの確認/作成
                string appDataPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "SearachAppSample");

                if (!Directory.Exists(appDataPath))
                {
                    Directory.CreateDirectory(appDataPath);
                }

                // アプリケーション実行
                Application.Run(new FormMain());
            }
            catch (Exception ex)
            {
                // 致命的なエラーの場合
                MessageBox.Show($"アプリケーション起動中に致命的なエラーが発生しました。\n{ex.Message}",
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine($"致命的なエラー: {ex}");
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            // UIスレッドでの未処理例外をハンドル
            Debug.WriteLine($"UIスレッド例外: {e.Exception}");
            MessageBox.Show($"予期しないエラーが発生しました。\n{e.Exception.Message}",
                "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // アプリケーションドメインでの未処理例外をハンドル
            var ex = e.ExceptionObject as Exception;
            Debug.WriteLine($"未処理の例外: {ex}");

            if (e.IsTerminating)
            {
                MessageBox.Show($"致命的なエラーが発生したためアプリケーションを終了します。\n{ex?.Message ?? "Unknown error"}",
                    "致命的なエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}