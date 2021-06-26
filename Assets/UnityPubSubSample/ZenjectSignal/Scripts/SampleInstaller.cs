using Zenject;

namespace xrdnk.UnityPubSubSample.ZenjectSignal
{
    public sealed class SampleInstaller : MonoInstaller<SampleInstaller>
    {
        public override void InstallBindings()
        {
            // Signal
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<StartSignal>().RequireSubscriber();
            // Service
            Container.BindInterfacesAndSelfTo<HelloWorldService>().AsSingle();
            // View
            Container.Bind<PublishView>().FromComponentInHierarchy().AsCached();
            // Presenter
            Container.BindInterfacesAndSelfTo<PubSubPresenter>().AsSingle();
        }
    }
}

