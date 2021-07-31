using UnityEngine;

namespace Scaperoth
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField]
        GameObjectEvent _onInteraction = new GameObjectEvent();

        public void Interact(GameObject actor)
        {
            _onInteraction?.Invoke(actor);
        }

        void Start()
        {
            if (_onInteraction == null)
                _onInteraction = new GameObjectEvent();
        }
    }

}