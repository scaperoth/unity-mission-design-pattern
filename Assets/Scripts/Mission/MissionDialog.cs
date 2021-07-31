using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scaperoth
{
    public class MissionDialog : MonoBehaviour
    {
        [SerializeField]
        DialogController _dialogController;
        [SerializeField]
        DialogData _dialogData;
        [SerializeField]
        DialogData _duringMissiondialogData;
        [SerializeField]
        DialogData _afterMissiondialogData;
        [SerializeField]
        MissionData _mission;

        public void OpenDialog(GameObject go)
        {
            Player player = go.GetComponent<Player>();

            if (_dialogController.IsOpen == true) return;

            DialogData currentDialog = _dialogData;
            Action callback = () => { };

            if (_mission.Active)
            {
                currentDialog = _duringMissiondialogData;
            }
            else if (_mission.Complete)
            {
                currentDialog = _afterMissiondialogData;
            }else
            {
                callback = () =>
                {
                    player.GetMission(_mission);
                };
            }

            _dialogController.OpenDialog(currentDialog, callback);
        }
    }

}