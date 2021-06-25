using UnityEngine;
using Zenject;

namespace xrdnk.UnityPubSubSample.Zenject
{
    public class UserJoinedSignal
    {
        public string UserName;
    }

    public class GameInitializer : IInitializable
    {
        private readonly SignalBus _signalBus;

        public GameInitializer(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Fire(new UserJoinedSignal{ UserName = "Denik" });
        }
    }

    public class Greeter
    {
        public void SayHello(UserJoinedSignal userJoinedInfo)
        {
            Debug.Log($"Hello {userJoinedInfo.UserName}!");
        }
    }
}
