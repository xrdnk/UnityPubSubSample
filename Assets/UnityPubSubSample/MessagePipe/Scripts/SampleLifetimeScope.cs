using MessagePipe;
using VContainer;
using VContainer.Unity;

namespace xrdnk.UnityPubSubSample.MessagePipe
{
    public sealed class SampleLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // Signal
            var option = builder.RegisterMessagePipe();
            builder.RegisterMessageBroker<StartSignal>(option);
            // Service
            builder.Register<HelloWorldService>(Lifetime.Singleton)
                .AsSelf().AsImplementedInterfaces();
            // View
            builder.RegisterComponentInHierarchy<PublishView>();
            // Presenter
            builder.RegisterEntryPoint<PubSubPresenter>();
        }
    }
}

