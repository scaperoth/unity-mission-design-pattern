using UnityEngine;
using UnityEngine.Events;


namespace Scaperoth {

    [CreateAssetMenu(menuName = "ScriptableObjects/MissionData")]
    public class MissionData: ScriptableObject
    {
        public enum Type
        {
            STORY = 0,
            SIDEQUEST
        }

        public static UnityEvent<MissionData, bool> OnCompleteChange = new UnityEvent<MissionData, bool>();
        public static UnityEvent<MissionData, bool> OnActiveChange = new UnityEvent<MissionData, bool>();
        public static UnityEvent<MissionData, bool> OnAvailableChange = new UnityEvent<MissionData, bool>();

        [SerializeField]
        string _name = "Mission Title";
        public string Name
        {
            get
            {
                return _name;
            }
        }
        [SerializeField]
        string _description = "Description that will show up in UI and guide the player";
        public string Description
        {
            get
            {
                return _description;
            }
        }
        [SerializeField]
        bool _active = false;
        public bool Active
        {
            get
            {
                return _active;
            }
        }
        [SerializeField]
        bool _complete = false;
        public bool Complete
        {
            get
            {
                return _complete;
            }
        }
        [SerializeField]
        bool _available = false;
        public bool Available
        {
            get {
                return _available;
            }
        }

        [SerializeField]
        Type _missionType = Type.SIDEQUEST;
        public Type MissionType
        {
            get
            {
                return _missionType;
            }
        }

        private void OnEnable()
        {
            _complete = false;
            _active = false;
        }

        public void SetComplete(bool complete)
        {
            _complete = complete;
            MissionData.OnCompleteChange.Invoke(this, complete);
        }

        public void SetActive(bool active)
        {
            _active = active;
            MissionData.OnActiveChange.Invoke(this, active);
        }
        public void SetAvailable(bool available)
        {
            _available = available;
            MissionData.OnAvailableChange.Invoke(this, available);
        }
    }

}