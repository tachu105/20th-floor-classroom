using UnityEngine;

namespace MCL.RunTime.DialogWindow
{
    /// <summary>
    /// ダイアログのモデル
    /// </summary>
    public sealed class DialogModel 
    {
        /// <summary>
        /// ダイアログのタイトル
        /// </summary>
        public readonly string dialogTitle = null;

        /// <summary>
        /// ダイアログのメインメッセージ
        /// </summary>
        public readonly string mainMessage = null;

        /// <summary>
        /// ダイアログのボタンの個数
        /// </summary>
        public readonly byte buttonCount = 0;

        /// <summary>
        /// ダイアログのボタンに表示するテキスト
        /// </summary>
        public readonly string[] buttonText = new string[3]; 

        /// <summary>
        /// ダイアログのボタンの色
        /// </summary>
        public readonly Color[] buttonColor = new Color[3];

        /// <summary>
        /// ダイアログでクリックされたボタンのインデックス
        /// </summary>
        public sbyte clickedButtonIndex { get; set; } = -1;
        
        public DialogModel(string dialogTitle, string mainMessage, byte buttonCount, string[] buttonText, Color[] buttonColor)
        {
            this.dialogTitle = dialogTitle;
            this.mainMessage = mainMessage;
            this.buttonCount = buttonCount;
            this.buttonText = buttonText;
            this.buttonColor = buttonColor;
            clickedButtonIndex = -1;
        }
    }
}
