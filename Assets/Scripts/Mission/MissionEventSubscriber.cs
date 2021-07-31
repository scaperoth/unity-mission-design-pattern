using UnityEngine;
using UnityEngine.Events;


namespace Scaperoth
{
    public class MissionEventSubscriber : MonoBehaviour
    {
        [SerializeField]
        UnityEvent<MissionData, bool> _onMissionComplete;
        [SerializeField]
        UnityEvent<MissionData, bool> _onMissionAvailable;
        [SerializeField]
        UnityEvent<MissionData, bool> _onMissionActive;

        private void Start()
        {
            MissionData.OnCompleteChange.AddListener(InvokeOnComplete);
            MissionData.OnAvailableChange.AddListener(InvokeOnAvailable);
            MissionData.OnActiveChange.AddListener(InvokeOnActive);
        }

        private void InvokeOnComplete(MissionData mission, bool complete)
        {
            _onMissionComplete.Invoke(mission, complete);
        }
        private void InvokeOnAvailable(MissionData mission, bool complete)
        {
            _onMissionAvailable.Invoke(mission, complete);
        }
        private void InvokeOnActive(MissionData mission, bool complete)
        {
            _onMissionActive.Invoke(mission, complete);
        }
    }

}