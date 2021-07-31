using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scaperoth
{

    public class Player : MonoBehaviour
    {

        [SerializeField]
        float _playerSpeed = 5f;
        [SerializeField]
        GameObject _interactableIcon;

        Transform _transform;

        bool _canInteract = false;
        Interactable _interactable;

        List<MissionData> _missions = new List<MissionData>();

        // Start is called before the first frame update
        void Start()
        {
            _transform = GetComponent<Transform>();
        }

        // Update is called once per frame
        void Update()
        {

            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            Vector3 move = new Vector3(horizontal, vertical, 0.0f);

            _transform.Translate(move * Time.deltaTime * _playerSpeed);

            if (_canInteract)
            {
                _interactableIcon.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    _interactable.Interact(gameObject);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Interactable interactable = collision.GetComponent<Interactable>();

            if (interactable != null)
            {
                _canInteract = true;
                _interactable = interactable;

            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            Interactable interactable = collision.GetComponent<Interactable>();

            if (interactable != null)
            {
                _canInteract = false;
                _interactable = null;
                _interactableIcon.SetActive(false);
            }

        }

        public void GetMission(MissionData newMission)
        {
            newMission.SetActive(true);
            _missions.Add(newMission);
            Debug.Log($"YOU'VE GOT A NEW MISSION!: {newMission.Name}");
            StartCoroutine(WaitAndFinishMission());
        }

        public void CompleteMission(MissionData completedMission)
        {
            foreach (MissionData mission in _missions)
            {
                if (mission == completedMission)
                {
                    Debug.Log($"FINISHED MISSION {mission.Name}");
                    mission.SetComplete(true);
                    mission.SetActive(false);
                }
            }
        }

        public IEnumerator WaitAndFinishMission()
        {
            yield return new WaitForSeconds(5);
            CompleteMission(_missions[_missions.Count - 1]);
        }
    }

}