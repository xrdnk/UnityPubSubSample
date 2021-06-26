using UniRx;
using UnityEngine;

namespace xrdnk.UnityPubSubSample.ZenjectSignal
{
    public class HelloWorldService
    {
        readonly StringReactiveProperty _userNameRp = new StringReactiveProperty();
        public IReadOnlyReactiveProperty<string> UserNameProperty => _userNameRp;

        public void SayHello(StartSignal args)
        {
            Debug.Log($"Hello {args.UserName}!");
            _userNameRp.Value = $"Hello {args.UserName}!";
        }
    }
}
