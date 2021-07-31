
using UnityEngine;

namespace Scaperoth
{
    [CreateAssetMenu(menuName = "ScriptableObjects/DialogData")]
    public class DialogData : ScriptableObject
    {
        [SerializeField]
        string[] _text;

        public string[] Text
        {
            get
            {
                return _text;
            }
        }
    }

}