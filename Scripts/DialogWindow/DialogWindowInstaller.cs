using MCL.RunTime.PlayerWindow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MCL.RunTime.DialogWindow
{
    /// <summary>
    /// DialogWindowシーンのインストーラー
    /// </summary>
    public class DialogWindowInstaller : MonoInstaller
    {
        [SerializeField] private DialogView dialogView = null;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<DialogPresenter>()
                .AsSingle();
            Container
                .BindInstance(dialogView)
                .AsSingle();
        }
    }
}
