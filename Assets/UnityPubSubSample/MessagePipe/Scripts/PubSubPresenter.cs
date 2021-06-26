using System;
using UniRx;

namespace xrdnk.UnityPubSubSample.MessagePipe
{
    public class PubSubPresenter : Zenject.IInitializable, VContainer.Unity.IInitializable, IDisposable
    {
        readonly HelloWorldService _service;
        readonly PublishView _view;
        readonly CompositeDisposable _disposable = new CompositeDisposable();

        [VContainer.Inject]
        [Zenject.Inject]
        public PubSubPresenter(HelloWorldService service, PublishView view)
        {
            _service = service;
            _view = view;
        }

        public void Initialize()
        {
            _service.UserNameProperty
                .Subscribe(_view.ShowMessage)
                .AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}