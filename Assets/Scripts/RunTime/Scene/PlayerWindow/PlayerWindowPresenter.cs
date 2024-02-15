using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using Zenject;

namespace MCL.RunTime.PlayerWindow
{
    using CoreSystem;

    /// <summary>
    /// PlayerWindowシーンのプレゼンタークラス
    /// </summary>
    public sealed class PlayerWindowPresenter : IDisposable, IInitializable
    {
        private readonly PlayerWindowView view;

        private readonly ISceneLoader sceneLoader;

        private readonly CancellationTokenSource destroyCancellationTokenSource = new CancellationTokenSource();

        private CancellationToken destroyCancellationToken => destroyCancellationTokenSource.Token;


        // Zenjectから注入される
        public PlayerWindowPresenter(PlayerWindowView view, ISceneLoader sceneLoader)
        {
            this.view = view;
            this.sceneLoader = sceneLoader;
        }


        void IInitializable.Initialize()
        {
            view.OnClickMenuButton
                .Subscribe(_ => UniTask.Void(async token =>
                {
                    await sceneLoader.LoadSceneAsyncAsAdditive(SceneName.MenuScene,token);
                    await sceneLoader.UnloadSceneAsync(SceneName.PlayerWindow,token);
                }, destroyCancellationToken))
                .AddTo(destroyCancellationToken);
        }

        void IDisposable.Dispose()
        {
            destroyCancellationTokenSource.Cancel();
            destroyCancellationTokenSource.Dispose();
        }
    }
}