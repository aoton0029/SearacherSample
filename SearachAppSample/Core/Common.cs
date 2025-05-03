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
        /*
         | トーン | 色名 | Hex | RGB |
        |:------|:---|:---|:---|
        | Lightest | SteelBlue50 | #e3eef7 | (227, 238, 247) |
        | Lighter | SteelBlue100 | #c0d6ec | (192, 214, 236) |
        | Light | SteelBlue200 | #9dbfe2 | (157, 191, 226) |
        | Base (Primary) | SteelBlue500 | #4682b4 | (70, 130, 180) |
        | Dark | SteelBlue700 | #2e5d85 | (46, 93, 133) |
        | Darker | SteelBlue800 | #264c6f | (38, 76, 111) |
        | Darkest | SteelBlue900 | #1f3d59 | (31, 61, 89) |

        | Role | Hex | 説明 |
        |:--|:--|:--|
        | Primary | #4682B4 | 基本のSteelBlue |
        | OnPrimary | #FFFFFF | Primary上のテキスト色（白） |
        | PrimaryContainer | #C9DDF0 | Primaryを薄めたコンテナ色 |
        | OnPrimaryContainer | #0E2A41 | PrimaryContainer上のテキスト色（深い青） |
        | Secondary | #5B9BD5 | Primaryをやや明るくした青 | 
        | OnSecondary | #FFFFFF | Secondary上のテキスト色 | 
        | SecondaryContainer | #D6E6F5 | Secondaryをさらに薄めた背景色 | 
        | OnSecondaryContainer | #1A3C5A | SecondaryContainer上のテキスト色 |
        | Tertiary | #7AA4C9 | 少しグレイッシュなSteelBlue系 | 
        | OnTertiary | #FFFFFF | Tertiary上のテキスト色 | 
        | TertiaryContainer | #DDE9F5 | Tertiaryをさらに明るく | 
        | OnTertiaryContainer | #23384D | TertiaryContainer上のテキスト色 |
        | Background | #F7FAFD | ごく淡い水色の背景 | 
        | OnBackground | #1E2E3E | 背景上のテキスト色 |
        | Surface | #F2F7FB | 背景より少し沈んだ面色 | 
        | OnSurface | #1E2E3E | Surface上のテキスト色 |
        | Outline | #8CAAC5 | 枠線・区切り線用（SteelBlueを薄めた） |
        | Error | #B3261E | 通常のMaterial Errorカラー | 
        | OnError | #FFFFFF | Error上のテキスト色 | 
        | ErrorContainer | #F9DEDC | エラー用背景色 | 
        | OnErrorContainer | #410E0B | Error背景上のテキスト色 |
         */

        public static readonly Color SteelBlueLightest = Color.FromArgb(227, 238, 247);
        public static readonly Color SteelBlueLighter = Color.FromArgb(192, 214, 236);
        public static readonly Color SteelBlueLight = Color.FromArgb(157, 191, 226);
        public static readonly Color SteelBlueBase = Color.FromArgb(70, 130, 180);
        public static readonly Color SteelBlueDark = Color.FromArgb(46, 93, 133);
        public static readonly Color SteelBlueDarker = Color.FromArgb(38, 76, 111);
        public static readonly Color SteelBlueDarkest = Color.FromArgb(31, 61, 89);

        public static void RunWithLoadingForm(string message, bool canCancel, Action<CancellationToken> action)
        {
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
        }

        //public static void RunWithLoadingForm(string message, bool canCancel, Action<CancellationToken> action)
        //{
        //    CancellationTokenSource cts = new CancellationTokenSource();
        //    using (var loadingForm = new FormLoading(message, canCancel, cts))
        //    {
        //        // フォームを表示する前に設定
        //        loadingForm.StartPosition = FormStartPosition.CenterScreen;

        //        // 非同期で処理を開始するためのタスク
        //        var actionTask = Task.Run(() =>
        //        {
        //            try
        //            {
        //                action(cts.Token);
        //            }
        //            catch (OperationCanceledException)
        //            {
        //                // キャンセルされた場合の処理
        //            }
        //            catch (Exception ex)
        //            {
        //                // 例外をキャプチャして後で再スロー
        //                return ex;
        //            }
        //            return null;
        //        });

        //        // イベントハンドラーの代わりに、タスク完了時にフォームを閉じる
        //        actionTask.ContinueWith(t =>
        //        {
        //            if (!loadingForm.IsDisposed && loadingForm.InvokeRequired)
        //            {
        //                loadingForm.Invoke((MethodInvoker)loadingForm.Close);
        //            }
        //        }, TaskScheduler.Default);

        //        // ダイアログを表示（これはUIスレッドをブロックする）
        //        loadingForm.ShowDialog();

        //        // アクションが例外をスローした場合は再スロー
        //        if (actionTask.IsCompleted && actionTask.Result is Exception ex)
        //        {
        //            throw new Exception("処理中にエラーが発生しました", ex);
        //        }
        //    }
        //}

        public static void RunWithLoadingFormInteractive(string message, bool canCancel, Action<CancellationToken, Action<Action>> action)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            using (var loadingForm = new FormLoading(message, canCancel, cts))
            {
                // フォームを表示する前に設定
                loadingForm.StartPosition = FormStartPosition.CenterScreen;

                // UIスレッドへのアクセス用のデリゲート（非同期）
                Action<Action> invokeOnUI = (uiAction) =>
                {
                    if (loadingForm.IsDisposed)
                        return;

                    if (loadingForm.InvokeRequired)
                    {
                        loadingForm.BeginInvoke(uiAction);
                    }
                    else
                    {
                        uiAction();
                    }

                    // LoadingFormの更新を確保
                    Application.DoEvents();
                };

                // タスクを実行
                Task.Run(() =>
                {
                    try
                    {
                        action(cts.Token, invokeOnUI);
                    }
                    catch (OperationCanceledException)
                    {
                        // キャンセルされた場合の処理
                    }
                    finally
                    {
                        if (!loadingForm.IsDisposed)
                        {
                            loadingForm.Invoke((MethodInvoker)loadingForm.Close);
                        }
                    }
                });

                // ダイアログを表示
                loadingForm.ShowDialog();
            }
        }


        public static void RunWithLoadingForm(string message, bool canCancel, Action<CancellationToken, IProgress<int>> action)
        {
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
                    finally
                    {
                        loadingForm.Invoke((MethodInvoker)loadingForm.Close);
                    }
                });

                loadingForm.ShowDialog();
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

    public class CustomColorPicker
    {
        public static Color ShowDialog(Color initialColor, string title = "色の選択")
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                // 基本的な設定
                colorDialog.AllowFullOpen = true;
                colorDialog.AnyColor = true;
                colorDialog.SolidColorOnly = false;
                colorDialog.Color = initialColor;
                colorDialog.CustomColors = GenerateCustomColorsFromSteelBlue();
                colorDialog.FullOpen = true;

                // ダイアログを表示
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    return colorDialog.Color;
                }

                return initialColor;
            }
        }

        private static int[] GenerateCustomColorsFromSteelBlue()
        {
            // カスタムカラーを設定 (ColorDialogは整数配列で色を指定する)
            int[] customColors = new int[16];

            // Common.csで定義されている色をカスタムカラーとして設定
            customColors[0] = ColorToArgb(Common.SteelBlueLightest);
            customColors[1] = ColorToArgb(Common.SteelBlueLighter);
            customColors[2] = ColorToArgb(Common.SteelBlueLight);
            customColors[3] = ColorToArgb(Common.SteelBlueBase);
            customColors[4] = ColorToArgb(Common.SteelBlueDark);
            customColors[5] = ColorToArgb(Common.SteelBlueDarker);
            customColors[6] = ColorToArgb(Common.SteelBlueDarkest);

            // 残りのカスタムカラースロットを他の色で埋める場合はここで設定

            return customColors;
        }

        private static int ColorToArgb(Color color)
        {
            // ColorDialogのCustomColorsはARGBではなくRGBの値を使用
            return color.ToArgb() & 0x00FFFFFF;
        }
    }

    public class CustomColorEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            // ボタンをクリックして編集するスタイルを返す
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService editorService =
                (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            if (editorService != null)
            {
                // 現在の色値を取得
                Color currentColor = (Color)value;

                // カスタムカラーダイアログを表示
                Color newColor = CustomColorPicker.ShowDialog(currentColor);

                // 新しい色を返す
                return newColor;
            }

            return value;
        }
    }
}
