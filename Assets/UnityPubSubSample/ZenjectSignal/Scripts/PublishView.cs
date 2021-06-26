using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace xrdnk.UnityPubSubSample.ZenjectSignal
{
    public sealed class PublishView : MonoBehaviour
    {
        [SerializeField] InputField _inputField;
        [SerializeField] Button _button;
        [SerializeField] Text _text;

        SignalBus _signalBus;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        void Awake()
        {
            _button.OnClickAsObservable()
                .Subscribe(_ => _signalBus.Fire(new StartSignal {UserName = _inputField.text}))
                .AddTo(this);
        }

        public void ShowMessage(string message)
        {
            _text.text = message;
        }
    }
}