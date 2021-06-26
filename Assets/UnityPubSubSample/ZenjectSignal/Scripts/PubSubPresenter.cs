using System;
using UniRx;
using Zenject;

namespace xrdnk.UnityPubSubSample.ZenjectSignal
{
    public class PubSubPresenter : IInitializable, IDisposable
    {
        readonly SignalBus _signalBus;
        readonly HelloWorldService _service;
        readonly PublishView _view;
        readonly CompositeDisposable _disposable = new CompositeDisposable();

        [Inject]
        public PubSubPresenter(SignalBus signalBus, HelloWorldService service, PublishView view)
        {
            _signalBus = signalBus;
            _service = service;
            _view = view;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<StartSignal>(_service.SayHello);

            _view.OnFiredAsObservable()
                .Subscribe(name => _signalBus.Fire(new StartSignal() {UserName = name}))
                .AddTo(_disposable);

            _service.UserNameProperty
                .Subscribe(_view.ShowMessage)
                .AddTo(_disposable);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<StartSignal>(_service.SayHello);
            _disposable.Dispose();
        }
    }
}