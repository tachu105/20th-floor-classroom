using Cysharp.Threading.Tasks;
using System.Threading;
using System;
using Zenject;

namespace MCL.RunTime.CoreSystem
{
    /// <summary>
    /// 列挙型でシーン遷移を行うインターフェース
    /// </summary>
    public interface ISceneLoader
    {
        /// <summary>
        /// Additiveでシーンをロードする
        /// </summary>
        /// <param name="sceneNameEnum"> ロードするシーン（列挙型）</param>
        void LoadSceneAsAdditive(SceneName sceneNameEnum);

        /// <summary>
        /// <para> Additiveでシーンをロードする <br/>
        /// また，ロードするシーンに対してDiConteinerの操作が可能 </para>
        /// 
        /// <see href = "https://monry.hatenablog.com/entry/2019/01/17/011116"> ZenjectSceneLoader参考サイト </see>
        /// </summary>
        /// <param name="sceneNameEnum"> ロードするシーン（列挙型）</param>
        /// <param name="container"> ロードするシーンに対するDiConteinerの操作</param>
        void LoadSceneAsAdditive(SceneName sceneNameEnum, Action<DiContainer> container);



        /// <summary>
        /// Additiveでシーンをロードする（UniTask）
        /// </summary>
        /// <param name="sceneNameEnum"> ロードするシーン（列挙型）</param>
        /// <param name="cancellationToken"> キャンセルトークン</param>
        /// <returns></returns>
        UniTask LoadSceneAsyncAsAdditive(SceneName sceneNameEnum, CancellationToken cancellationToken);

        /// <summary>
        /// <para> Additiveでシーンをロードする（UniTask）<br/>
        /// また，ロードするシーンに対してDiConteinerの操作が可能 </para>
        /// 
        /// <see href = "https://monry.hatenablog.com/entry/2019/01/17/011116"> ZenjectSceneLoader参考サイト </see>
        /// </summary>
        /// <param name="sceneNameEnum"> ロードするシーン（列挙型）</param>
        /// <param name="container"> ロードするシーンに対するDiConteinerの操作</param>
        /// <param name="cancellationToken"> キャンセルトークン</param>
        /// <returns></returns>
        UniTask LoadSceneAsyncAsAdditive(SceneName sceneNameEnum, Action<DiContainer> container, CancellationToken cancellationToken);



        /// <summary>
        /// シーンを削除する（UniTask）
        /// </summary>
        /// <param name="sceneNameEnum"> 削除するシーン（列挙型）</param>
        /// <param name="cancellationToken"> キャンセルトークン</param>
        /// <returns></returns>
        UniTask UnloadSceneAsync(SceneName sceneNameEnum, CancellationToken cancellationToken);
    }
}
