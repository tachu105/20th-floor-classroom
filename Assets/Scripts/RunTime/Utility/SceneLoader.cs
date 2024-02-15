using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using System;
using UnityEngine.SceneManagement;
using Zenject;

namespace MCL.RunTime.CoreSystem
{
    /// <summary>
    /// 使用可能シーンの列挙型
    /// </summary>
    public enum SceneName
    {
        MenuScene,
        PlayerWindow,
        DialogWindow,
    }

    /// <summary>
    /// SceneManagerのラッパークラス
    /// 列挙型でシーン指定を可能にするもの
    /// </summary>
    public class SceneLoader : ISceneLoader
    {
        /// <summary>
        /// <para> zenjectのシーンローダー </para>
        /// <para> ロード時にBindさせることで，シーン間でのデータ（クラスなど）の受け渡しを可能にする機能がある </para>
        /// <see href = "https://monry.hatenablog.com/entry/2019/01/17/011116"> ZenjectSceneLoader参考サイト </see>
        /// </summary>
        private readonly ZenjectSceneLoader zenjectSceneLoader;

        //注入される
        public SceneLoader(ZenjectSceneLoader sceneLoader)
        {
            this.zenjectSceneLoader = sceneLoader;
        }

        //enumからstringへの変換用
        Dictionary<SceneName, string> sceneNameStr = new Dictionary<SceneName, string>()
        {
            { SceneName.MenuScene, "MenuScene" },
            { SceneName.PlayerWindow, "PlayerWindow" },
            { SceneName.DialogWindow, "DialogWindow"},
        };




        void ISceneLoader.LoadSceneAsAdditive(SceneName sceneNameEnum)
        {
            SceneManager.LoadScene(
                        sceneNameStr[sceneNameEnum], 
                        LoadSceneMode.Additive
                        );
        }
        void ISceneLoader.LoadSceneAsAdditive(SceneName sceneNameEnum, Action<DiContainer> container)
        {
            zenjectSceneLoader.LoadScene(
                    sceneNameStr[sceneNameEnum], 
                    LoadSceneMode.Additive,
                    container
                );
        }


        async UniTask ISceneLoader.LoadSceneAsyncAsAdditive(SceneName sceneNameEnum, CancellationToken cancellationToken)
        {
            await SceneManager.LoadSceneAsync(
                    sceneNameStr[sceneNameEnum],
                    LoadSceneMode.Additive
                ).WithCancellation(cancellationToken);
        }
        async UniTask ISceneLoader.LoadSceneAsyncAsAdditive(SceneName sceneNameEnum, Action<DiContainer> container, CancellationToken cancellationToken)
        {
            await zenjectSceneLoader.LoadSceneAsync(
                        sceneNameStr[sceneNameEnum],
                        LoadSceneMode.Additive,
                        container
                    ).WithCancellation(cancellationToken);
        }


        async UniTask ISceneLoader.UnloadSceneAsync(SceneName sceneNameEnum, CancellationToken cancellationToken)
        {
            await SceneManager.UnloadSceneAsync(sceneNameStr[sceneNameEnum]).WithCancellation(cancellationToken);
        }
    }
}
