using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace xrdnk.UnityPubSubSample.MessageBroker
{
    public class HelloWorldService : IInitializable, IDisposable
    {
        readonly StringReactiveProperty _userNameRp = new StringReactiveProperty();
        public IReadOnlyReactiveProperty<string> UserNameProperty => _userNameRp;

        readonly CompositeDisposable _disposable = new CompositeDisposable();

        public void Initialize()
        {
            UniRx.MessageBroker.Default.Receive<StartSignal>()
                .Subscribe(SayHello)
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