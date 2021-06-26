using Zenject;

namespace xrdnk.UnityPubSubSample.MessageBroker
{
    public sealed class SampleInstaller : MonoInstaller<SampleInstaller>
    {
        public override void InstallBindings()
        {
            // Service
            Container.BindInterfacesAndSelfTo<HelloWorldService>().AsSingle();
            // View
            Container.Bind<PublishView>().FromComponentInHierarchy().AsCached();
            // Presenter
            Container.BindInterfacesAndSelfTo<PubSubPresenter>().AsSingle();
        }
    }
}