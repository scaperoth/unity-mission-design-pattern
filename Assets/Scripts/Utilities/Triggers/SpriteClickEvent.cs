using UnityEngine;
using UnityEngine.EventSystems;

namespace Scaperoth {

    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Sprite))]
    public class SpriteClickEvent : MonoBehaviour
    {
        [SerializeField]
        EventTrigger.TriggerEvent _functionToFire;
        [SerializeField]
        Sprite _activeSprite;
        [SerializeField]

        // unserialized fields
        Sprite _unpressedSprite;
        SpriteRenderer _spriteRenderer;
        BaseEventData _eventData;

        private bool _clickEnabled = true;

        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            if (_spriteRenderer != null)
            {
                _unpressedSprite = _spriteRenderer.sprite;
            }
            _eventData = new BaseEventData(EventSystem.current);
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnDisable()
        {
            if (_spriteRenderer != null)
            {
                _spriteRenderer.sprite = _unpressedSprite;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnMouseDown()
        {
            if (_clickEnabled)
            {
                if (_spriteRenderer != null)
                {
                    _spriteRenderer.sprite = _activeSprite;
                }

                _functionToFire.Invoke(_eventData);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnMouseUp()
        {
            if (_clickEnabled)
            {
                if (_spriteRenderer != null)
                {
                    _spriteRenderer.sprite = _unpressedSprite;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enableClick"></param>
        public void EnableClick(bool enableClick)
        {
            _clickEnabled = enableClick;
        }
    }

}