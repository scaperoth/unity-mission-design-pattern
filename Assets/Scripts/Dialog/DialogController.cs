using UnityEngine;
using System;
using TMPro;

namespace Scaperoth
{
    public class DialogController : MonoBehaviour
    {
        [SerializeField]
        DialogText _dialogContainer;

        Action _callback;
        Transform _transform;
        int _currentText = 0;
        DialogData _dialogData;
        bool _isOpen = false;
        public bool IsOpen
        {
            get
            {
                return _isOpen;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            _transform = GetComponent<Transform>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                onNextDialog();
            }
        }

        void UpdateText(string text)
        {
            _dialogContainer.UpdateText(text);
        }

        public void OnClose()
        {
            gameObject.SetActive(false);
            _currentText = 0;
            _isOpen = false;
            _callback?.Invoke();
        }

        public void onNextDialog()
        {
            _currentText++;

            if (_currentText >= _dialogData.Text.Length)
            {
                OnClose();
                return;
            }
            UpdateText(_dialogData.Text[_currentText]);
        }

        public void OpenDialog(DialogData dialogData, Action onCloseCallback)
        {
            _dialogData = dialogData;
            _callback = onCloseCallback;
            gameObject.SetActive(true);
            _isOpen = true;
            UpdateText(_dialogData.Text[_currentText]);
        }

    }

}