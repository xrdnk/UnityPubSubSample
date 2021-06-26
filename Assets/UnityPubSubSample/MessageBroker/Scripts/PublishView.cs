using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace xrdnk.UnityPubSubSample.MessageBroker
{
    public sealed class PublishView : MonoBehaviour
    {
        [SerializeField] InputField _inputField;
        [SerializeField] Button _button;
        [SerializeField] Text _text;

        void Awake()
        {
            _button.OnClickAsObservable()
                .Subscribe(_ => UniRx.MessageBroker.Default.Publish(new StartSignal(){UserName = _inputField.text}))
                .AddTo(this);
        }

        public void ShowMessage(string message)
        {
            _text.text = message;
        }
    }
}