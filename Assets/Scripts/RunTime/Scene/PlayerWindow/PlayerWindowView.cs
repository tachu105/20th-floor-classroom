using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace MCL.RunTime.PlayerWindow
{
    /// <summary>
    /// PlayerWindowシーンのビュークラス
    /// </summary>
    public sealed class PlayerWindowView : MonoBehaviour
    {
        [SerializeField]
        private Button menuBtn = null;

        /// <summary>
        /// メニューボタンが押されたときのイベント
        /// </summary>
        public IObservable<Unit> OnClickMenuButton
        {
            get => menuBtn.OnClickAsObservable();
            // setはないよ
        }
    }
}
