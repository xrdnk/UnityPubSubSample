using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace xrdnk.UnityPubSubSample.ZenjectSignal
{
    public class PublishView : MonoBehaviour
    {
        [SerializeField] InputField _inputField;
        [SerializeField] Button _button;
        [SerializeField] Text _text;

        readonly Subject<string> _fireSubject = new Subject<string>();
        public IObservable<string> OnFiredAsObservable() => _fireSubject;

        void Awake()
        {
            _button.OnClickAsObservable()
                .Subscribe(_ => _fireSubject.OnNext(_inputField.text))
                .AddTo(this);
        }

        public void ShowMessage(string message)
        {
            _text.text = message;
        }
    }
}