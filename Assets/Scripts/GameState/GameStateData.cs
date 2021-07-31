using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scaperoth
{

    [CreateAssetMenu(menuName = "ScriptableObjects/GameStateData")]
    public class GameStateData : ScriptableObject
    {
        [SerializeField]
        Game.State _gameState = Game.State.CHAPTER_1;

        [SerializeField]
        List<MissionData> _allMissions = new List<MissionData>();
        [SerializeField]
        List<MissionData> _availableMissions = new List<MissionData>();
        [SerializeField]
        List<MissionData> _activeMissions = new List<MissionData>();
        [SerializeField]
        List<MissionData> _completedMissions = new List<MissionData>();

        public void OnEnable()
        {
            foreach (MissionData mission in _allMissions)
            {
                mission.SetAvailable(false);
                mission.SetActive(false);
                mission.SetComplete(false);
            }
            foreach (MissionData mission in _availableMissions)
            {
                mission.SetAvailable(true);
            }
            foreach (MissionData mission in _activeMissions)
            {
                mission.SetAvailable(true);
                mission.SetActive(true);
            }
            foreach (MissionData mission in _completedMissions)
            {
                mission.SetAvailable(true);
                mission.SetActive(false);
                mission.SetComplete(true);
            }
        }

        public void SetGameState(Game.State newState)
        {
            _gameState = newState;
        }
    }

}