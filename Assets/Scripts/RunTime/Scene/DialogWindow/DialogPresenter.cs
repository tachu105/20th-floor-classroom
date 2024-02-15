using Cysharp.Threading.Tasks;
using System.Threading;
using Zenject;
using System;

namespace MCL.RunTime.DialogWindow
{
    /// <summary>
    /// ダイアログのPresenter
    /// </summary>
    public class DialogPresenter : IDisposable, IInitializable
    {
        private readonly DialogModel dialogModel = null;
        private readonly DialogView dialogView = null;

        private readonly CancellationTokenSource destroyCancellationTokenSource = new CancellationTokenSource();
        private CancellationToken destroyCancellationToken => destroyCancellationTokenSource.Token;

        public DialogPresenter(DialogModel dialogModel, DialogView dialogView)
        {
            this.dialogModel = dialogModel;
            this.dialogView = dialogView;
        }


        //シーン生成時に呼ばれる
        void IInitializable.Initialize()
        {
            if (dialogModel.buttonText.Length < 1 || 3 < dialogModel.buttonText.Length)
                throw new ArgumentException("ボタンText配列は要素数1～3にしてください.");
            if (dialogModel.buttonColor.Length < 1 || 3 < dialogModel.buttonColor.Length)
                throw new ArgumentException("ボタンColor配列は要素数1～3にしてください.");

            //Viewへのデータ反映
            dialogView.dialogTitleText = dialogModel.dialogTitle;
            dialogView.mainMessageText = dialogModel.mainMessage;
            dialogView.dialogButtonTexts = dialogModel.buttonText;
            dialogView.dialogButtonColors = dialogModel.buttonColor;
            dialogView.dialogButtonCount = dialogModel.buttonCount;

            //ボタンのクリック時動作の購読開始
            for(byte i = 0; i < dialogModel.buttonCount; i++)
            {
                //各ボタンのクリック時の動作
                UniTask.Void(async index =>
                {
                    await dialogView.dialogButtons[index].OnClickAsync(destroyCancellationToken);
                    dialogModel.clickedButtonIndex = (sbyte)index;
                },i);
            }
        }

        //シーン削除時に呼ばれる
        void IDisposable.Dispose()
        {
            destroyCancellationTokenSource.Cancel();
            destroyCancellationTokenSource.Dispose();
        }
    }
}
