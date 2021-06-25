using Zenject;

namespace xrdnk.UnityPubSubSample.Zenject
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<UserJoinedSignal>();
            Container.Bind<Greeter>().AsSingle();
            Container.BindSignal<UserJoinedSignal>().ToMethod<Greeter>(x => x.SayHello).FromResolve();
            Container.BindInterfacesTo<GameInitializer>().AsSingle();
        }
    }
}

