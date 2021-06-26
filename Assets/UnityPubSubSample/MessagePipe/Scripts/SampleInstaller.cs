using MessagePipe;
using Zenject;

namespace xrdnk.UnityPubSubSample.MessagePipe
{
    public class SampleInstaller : MonoInstaller<SampleInstaller>
    {
        public override void InstallBindings()
        {
            // Signal
            var option = Container.BindMessagePipe();
            Container.BindMessageBroker<StartSignal>(option);
            // Service
            Container.BindInterfacesAndSelfTo<HelloWorldService>().AsSingle();
            // View
            Container.Bind<PublishView>().FromComponentInHierarchy().AsCached();
            // Presenter
            Container.BindInterfacesAndSelfTo<PubSubPresenter>().AsSingle();
        }
    }
}