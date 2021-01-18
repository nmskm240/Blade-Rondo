using UnityEngine;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;

namespace BladeRondo.System
{    
    public class TurnManager : MonoBehaviour, IPunTurnManagerCallbacks 
    {
        [SerializeField]
        private PunTurnManager turnManager;

        private void Awake() 
        {
            turnManager.TurnManagerListener = this;
        }

        public void OnTurnBegins(int turn)
        {

        }

        public void OnTurnCompleted(int turn)
        {

        }

        public void OnPlayerMove(Player player, int turn, object move)
        {

        }

        public void OnPlayerFinished(Player player, int turn, object move)
        {

        }

        public void OnTurnTimeEnds(int turn)
        {

        }
    }
}