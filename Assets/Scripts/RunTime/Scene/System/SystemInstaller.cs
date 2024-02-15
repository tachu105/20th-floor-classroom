using Zenject;

namespace MCL.RunTime.System
{
    using CoreSystem;

    /// <summary>
    /// Systemシーンのインストーラー
    /// </summary>
    public class SystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<IDialogController>().To<DialogController>().AsSingle();
        }
    }
}
