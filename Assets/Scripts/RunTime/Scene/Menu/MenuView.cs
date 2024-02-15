using UnityEngine;
using UniRx;
using UnityEngine.UI;
using System;

namespace MCL.RunTime.Menu
{
    //  Unityの画面として表示する最低限の実装
    public class MenuView : MonoBehaviour
    {
        [SerializeField]
        private Button returnBtn;

        public IObservable<Unit> ReturnButtonClick
        {
            get
            {
                return returnBtn.OnClickAsObservable();
            }
        }
    }
}
