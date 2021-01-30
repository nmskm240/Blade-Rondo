using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;
using BladeRondo.Network.CustomProperties.Players;

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

        private void Start()
        {
            PhotonNetwork.LocalPlayer.SetHP(15);
            PhotonNetwork.LocalPlayer.SetMaxVoltage(0);
            PhotonNetwork.LocalPlayer.SetNowVoltage(0);
            PhotonNetwork.LocalPlayer.SetAttack(0);
            PhotonNetwork.LocalPlayer.SetDefence(0);
            if(PhotonNetwork.IsMasterClient)
            {
                turnManager.BeginTurn();
            }
        }

        public void OnTurnBegins(int turn)
        {
            PhotonNetwork.LocalPlayer.SetNowVoltage(PhotonNetwork.LocalPlayer.GetMaxVoltage() + 1);
            PhotonNetwork.LocalPlayer.AddMaxVoltage(1);
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

        public void TurnEnd()
        {
            turnManager.SendMove(null, true);
        }
    }
}