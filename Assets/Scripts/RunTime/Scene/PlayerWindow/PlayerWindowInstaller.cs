using Zenject;

namespace MCL.RunTime.PlayerWindow
{
    public sealed class PlayerWindowInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<PlayerWindowPresenter>()
                .AsSingle();
        }
    }
}