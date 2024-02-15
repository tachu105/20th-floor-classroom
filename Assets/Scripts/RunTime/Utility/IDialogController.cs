using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

namespace MCL.RunTime.System
{
    /// <summary>
    /// ダイアログの制御を行うインターフェース
    /// </summary>
    public interface IDialogController
    {
        /// <summary>
        /// <para> ダイアログを表示するメソッド </para>
        /// <para> 表示するボタンの個数は1～3つの範囲で指定すること </para>
        /// </summary>
        /// <param name="dialogTitle"> タイトル</param>
        /// <param name="mainMessage"> メインテキスト</param>
        /// <param name="buttonCount"> 表示するボタンの個数（1～3）</param>
        /// <param name="buttonText"> ボタンに表示するテキスト</param>
        /// <param name="buttonColor"> ボタンの色</param>
        /// <param name="cancellationToken"></param>
        /// <returns> クリックされたボタンのインデックス</returns>
        UniTask<sbyte> PopupDialogAsync(string dialogTitle, string mainMessage, byte buttonCount, string[] buttonText, Color[] buttonColor, CancellationToken cancellationToken);

        /// <summary>
        /// <para> ダイアログを表示するメソッド </para>
        /// <para> 表示するボタンの個数が1つの場合 </para>
        /// </summary>
        /// <param name="dialogTitle"> タイトル</param>
        /// <param name="mainMessage"> メインテキスト</param>
        /// <param name="buttonText"> ボタンに表示するテキスト</param>
        /// <param name="buttonColor"> ボタンの色</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        UniTask<sbyte> PopupDialogAsync(string dialogTitle, string mainMessage, string buttonText, Color buttonColor, CancellationToken cancellationToken)
        {
            string[] buttonTextArray = new string[] {buttonText};
            Color[] buttonColorArray = new Color[] {buttonColor};
            return PopupDialogAsync(dialogTitle, mainMessage, 1, buttonTextArray, buttonColorArray, cancellationToken);
        }

        /// <summary>
        /// <para> ダイアログを表示するメソッド </para>
        /// <para> 表示するボタンの個数が2つの場合 </para>
        /// </summary>
        /// <param name="dialogTitle"> タイトル</param>
        /// <param name="mainMessage"> メインテキスト</param>
        /// <param name="button0Text"> 0番目のボタンに表示するテキスト</param>
        /// <param name="button1Text"> 1番目のボタンに表示するテキスト</param>
        /// <param name="button0Color"> 0番目のボタンの色</param>
        /// <param name="button1Color"> 1番目のボタンの色</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        UniTask<sbyte> PopupDialogAsync(string dialogTitle, string mainMessage, string button0Text, string button1Text, Color button0Color, Color button1Color, CancellationToken cancellationToken)
        {
            string[] buttonTextArray = new string[] {button0Text, button1Text};
            Color[] buttonColorArray = new Color[] {button0Color, button1Color};
            return PopupDialogAsync(dialogTitle, mainMessage, 2, buttonTextArray, buttonColorArray, cancellationToken);
        }
        
        /// <summary>
        /// <para> ダイアログを表示するメソッド </para>
        /// <para> 表示するボタンの個数が3つの場合 </para>
        /// </summary>
        /// <param name="dialogTitle"> タイトル</param>
        /// <param name="mainMessage"> メインテキスト</param>
        /// <param name="button0Text"> 0番目のボタンに表示するテキスト</param>
        /// <param name="button1Text"> 1番目のボタンに表示するテキスト</param>
        /// <param name="button2Text"> 2番目のボタンに表示するテキスト</param>
        /// <param name="button0Color"> 0番目のボタンの色</param>
        /// <param name="button1Color"> 1番目のボタンの色</param>
        /// <param name="button2Color"> 2番目のボタンの色</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        UniTask<sbyte> PopupDialogAsync(string dialogTitle, string mainMessage, string button0Text, string button1Text, string button2Text, Color button0Color, Color button1Color, Color button2Color, CancellationToken cancellationToken)
        {
            string[] buttonTextArray = new string[] {button0Text, button1Text, button2Text};
            Color[] buttonColorArray = new Color[] {button0Color, button1Color, button2Color};
            return PopupDialogAsync(dialogTitle, mainMessage, 3, buttonTextArray, buttonColorArray, cancellationToken);
        }
    }
}
