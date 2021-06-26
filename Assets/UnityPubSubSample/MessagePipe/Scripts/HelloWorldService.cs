using System;
using MessagePipe;
using UniRx;
using UnityEngine;

namespace xrdnk.UnityPubSubSample.MessagePipe
{
    public sealed class HelloWorldService : Zenject.IInitializable, VContainer.Unity.IInitializable, IDisposable
    {
        readonly ISubscriber<StartSignal> _startSubscriber;

        readonly StringReactiveProperty _userNameRp = new StringReactiveProperty();
        public IReadOnlyReactiveProperty<string> UserNameProperty => _userNameRp;

        readonly CompositeDisposable _disposable = new CompositeDisposable();

        [VContainer.Inject]
        [Zenject.Inject]
        public HelloWorldService(ISubscriber<StartSignal> startSubscriber)
        {
            _startSubscriber = startSubscriber;
        }

        public void Initialize()
        {
            _startSubscriber.Subscribe(SayHello)
                .AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }

        void SayHello(StartSignal args)
        {
            Debug.Log($"Hello {args.UserName}!");
            _userNameRp.Value = $"Hello {args.UserName}!";
        }
    }
}