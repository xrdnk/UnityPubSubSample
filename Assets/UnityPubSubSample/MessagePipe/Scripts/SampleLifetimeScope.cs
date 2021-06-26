using MessagePipe;
using VContainer;
using VContainer.Unity;
using xrdnk.UnityPubSubSample.MessagePipe;

public class SampleLifetimeScope : LifetimeScope
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
