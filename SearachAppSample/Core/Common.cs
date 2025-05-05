using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace SearachAppSample.Core
{
    public class Common
    {
        public static void RunWithLoadingForm(string message, bool canCancel, Action<CancellationToken> action)
        {
            Exception capturedException = null;
            CancellationTokenSource cts = new CancellationTokenSource();
            using (var loadingForm = new FormLoading(message, canCancel, cts))
            {
                // フォームを表示する前に設定
                loadingForm.StartPosition = FormStartPosition.CenterScreen;

                // タスクを実行
                Task.Run(() =>
                {
                    try
                    {
                        action(cts.Token);
                    }
                    catch (OperationCanceledException)
                    {
                        // キャンセルされた場合の処理
                    }
                    catch (Exception ex)
                    {
                        // 例外をキャッチして保存
                        capturedException = ex;
                    }
                    finally
                    {
                        if (!loadingForm.IsDisposed && loadingForm.InvokeRequired)
                        {
                            loadingForm.Invoke((MethodInvoker)loadingForm.Close);
                        }
                    }
                });
                // ダイアログを表示
                loadingForm.ShowDialog();
            }

            if(capturedException != null)
            {
                throw capturedException;
            }
        }


        public static void RunWithLoadingForm(string message, bool canCancel, Action<CancellationToken, IProgress<int>> action)
        {
            Exception capturedException = null;
            CancellationTokenSource cts = new CancellationTokenSource();
            using (var loadingForm = new FormLoading(message, canCancel, cts))
            {
                // プログレス報告用
                var progress = new Progress<int>(value => loadingForm.UpdateProgress(value));

                // タスクを実行
                Task.Run(() =>
                {
                    try
                    {
                        action(cts.Token, progress);
                    }
                    catch (OperationCanceledException)
                    {
                        // キャンセルされた場合の処理
                    }
                    catch (Exception ex)
                    {
                        // 例外をキャッチして保存
                        capturedException = ex;
                    }
                    finally
                    {
                        loadingForm.Invoke((MethodInvoker)loadingForm.Close);
                    }
                });

                loadingForm.ShowDialog();
            }

            if (capturedException != null)
            {
                throw capturedException;
            }
        }

        public static async Task<T> RunWithLoadingFormAsync<T>(string message, bool canCancel, Func<CancellationToken, Task<T>> func)
        {
            T result = default;
            CancellationTokenSource cts = new CancellationTokenSource();
            using (var loadingForm = new FormLoading(message, canCancel, cts))
            {
                // タスクを実行
                var task = Task.Run(async () =>
                {
                    try
                    {
                        result = await func(cts.Token);
                    }
                    catch (OperationCanceledException)
                    {
                        // キャンセルされた場合の処理
                    }
                    finally
                    {
                        loadingForm.Invoke((MethodInvoker)loadingForm.Close);
                    }
                });

                loadingForm.ShowDialog();
                await task;
            }
            return result;
        }

        public static async Task<T> RunWithLoadingFormAsync<T>(string message, bool canCancel, Func<CancellationToken, IProgress<int>, Task<T>> func)
        {
            T result = default;
            CancellationTokenSource cts = new CancellationTokenSource();
            using (var loadingForm = new FormLoading(message, canCancel, cts))
            {
                // プログレス報告用
                var progress = new Progress<int>(value => loadingForm.UpdateProgress(value));

                // タスクを実行
                var task = Task.Run(async () =>
                {
                    try
                    {
                        result = await func(cts.Token, progress);
                    }
                    catch (OperationCanceledException)
                    {
                        // キャンセルされた場合の処理
                    }
                    finally
                    {
                        loadingForm.Invoke((MethodInvoker)loadingForm.Close);
                    }
                });

                loadingForm.ShowDialog();
                await task;
            }
            return result;
        }
    }

}
