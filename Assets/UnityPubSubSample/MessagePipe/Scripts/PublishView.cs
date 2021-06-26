using MessagePipe;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace xrdnk.UnityPubSubSample.MessagePipe
{
    public sealed class PublishView : MonoBehaviour
    {
        [SerializeField] InputField _inputField;
        [SerializeField] Button _button;
        [SerializeField] Text _text;

        IPublisher<StartSignal> _startPublisher;

        [VContainer.Inject]
        [Zenject.Inject]
        public void Construct(IPublisher<StartSignal> startPublisher)
        {
            _startPublisher = startPublisher;
        }

        void Awake()
        {
            _button.OnClickAsObservable()
                .Subscribe(_ => _startPublisher.Publish(new StartSignal(){UserName = _inputField.text}))
                .AddTo(this);
        }

        public void ShowMessage(string message)
        {
            _text.text = message;
        }
    }
}