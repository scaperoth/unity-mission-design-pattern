using UnityEngine;

namespace Scaperoth
{
    [RequireComponent(typeof(TextTyper))]
    public class DialogText : MonoBehaviour
    {
        TextTyper _textTyper;

        // Use this for initialization
        void Awake()
        {
            _textTyper = GetComponent<TextTyper>();
        }

        public void UpdateText(string text)
        {
            _textTyper.UpdateText(text);
        }

        public void RsetText()
        {
            _textTyper.Clear();
        }
    }

}