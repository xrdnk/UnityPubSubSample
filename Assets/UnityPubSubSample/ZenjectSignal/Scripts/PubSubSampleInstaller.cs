using Zenject;

namespace xrdnk.UnityPubSubSample.ZenjectSignal
{
    public sealed class PubSubSampleInstaller : MonoInstaller<PubSubSampleInstaller>
    {
        public override void InstallBindings()
        {
            // Signal
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<StartSignal>().RequireSubscriber();
            // Service
            Container.Bind<HelloWorldService>().AsSingle();
            // View
            Container.Bind<PublishView>().FromComponentInHierarchy().AsCached();
            // Presenter
            Container.BindInterfacesTo<PubSubPresenter>().AsSingle();
        }
    }
}

