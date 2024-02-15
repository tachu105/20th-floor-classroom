using UnityEngine;
using System;
using Cysharp.Threading.Tasks;
using System.Threading;
using Zenject;

namespace MCL.RunTime.System
{
    using CoreSystem;
    using DialogWindow;

    /// <summary>
    /// ダイアログの制御を行うクラス
    /// </summary>
    public class DialogController : IDialogController
    {
        private readonly ISceneLoader sceneLoader = null;

        public DialogController(ISceneLoader sceneLoader)
        {
            this.sceneLoader = sceneLoader;
        }

       
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
        async UniTask<sbyte> IDialogController.PopupDialogAsync(string dialogTitle, string mainMessage, byte buttonCount, string[] buttonText, Color[] buttonColor, CancellationToken cancellationToken)
        {
            if (buttonCount < 1 || 3 < buttonCount)  throw new ArgumentException("ボタンの個数が1～3つの範囲で使用可能です．");
            if (buttonCount != buttonText.Length) throw new ArgumentException("ボタンの個数とボタンのテキスト配列の要素数が一致しません");
            if (buttonCount != buttonColor.Length) throw new ArgumentException("ボタンの個数とボタンの色配列の要素数が一致しません");

            DialogModel dialogModel = new DialogModel(dialogTitle, mainMessage, buttonCount, buttonText, buttonColor);

            //ダイアログシーンを開く
            await sceneLoader.LoadSceneAsyncAsAdditive(SceneName.DialogWindow, (DiContainer container) =>
            {
                container.BindInstance(dialogModel).AsSingle();
            }, cancellationToken);

            //ボタンがクリックされるまで待機して，シーン削除
            await UniTask.WaitUntil(() => dialogModel.clickedButtonIndex != -1, cancellationToken: cancellationToken);
            await sceneLoader.UnloadSceneAsync(SceneName.DialogWindow, cancellationToken);

            return dialogModel.clickedButtonIndex;
        }
    }
}
