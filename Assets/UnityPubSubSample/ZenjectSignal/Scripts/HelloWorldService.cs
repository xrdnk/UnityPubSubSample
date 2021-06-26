using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace xrdnk.UnityPubSubSample.ZenjectSignal
{
    public sealed class HelloWorldService : IInitializable, IDisposable
    {
        readonly SignalBus _signalBus;

        readonly StringReactiveProperty _userNameRp = new StringReactiveProperty();
        public IReadOnlyReactiveProperty<string> UserNameProperty => _userNameRp;

        [Inject]
        public HelloWorldService(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<StartSignal>(SayHello);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<StartSignal>(SayHello);
        }

        void SayHello(StartSignal args)
        {
            Debug.Log($"Hello {args.UserName}!");
            _userNameRp.Value = $"Hello {args.UserName}!";
        }
    }
}
