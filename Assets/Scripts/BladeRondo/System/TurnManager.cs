using System.Collections;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;
using BladeRondo.Network.CustomProperties.Players;
using BladeRondo.Network.CustomProperties.Rooms;
using BladeRondo.System.TurnState.Phases;

namespace BladeRondo.System
{    
    public class TurnManager : MonoBehaviour, IPunTurnManagerCallbacks 
    {
        [SerializeField]
        private PunTurnManager _turnManager;

        private IState NowPhase;

        private void Awake() 
        {
            _turnManager.TurnManagerListener = this;
        }

        private IEnumerator Start()
        {
            if(PhotonNetwork.IsMasterClient)
            {
                var startPlayerId = Random.Range(0,2);
                var startPlayer = PhotonNetwork.PlayerList[startPlayerId];
                PhotonNetwork.CurrentRoom.SetTurnPlayer(startPlayer);
            }
            NowPhase = new FirstPick();
            NowPhase.Execute();
            yield return new WaitWhile( () => PhotonNetwork.LocalPlayer.GetStartCheck() || PhotonNetwork.PlayerListOthers[0].GetStartCheck() );
            NowPhase = new BattleSetup();
            NowPhase.Execute();
            _turnManager.BeginTurn();
        }

        public void OnTurnBegins(int turn)
        {
            if(PhotonNetwork.CurrentRoom.GetTurnPlayer() == PhotonNetwork.LocalPlayer)
            {
                NowPhase = new Standby();
                NowPhase.Execute();
                NowPhase = new Main();
                NowPhase.Execute();
            }
            else
            {
                TurnEnd();
            }
        }

        public void OnTurnCompleted(int turn)
        {
            if(PhotonNetwork.CurrentRoom.GetTurnPlayer() == PhotonNetwork.LocalPlayer)
            {
                NowPhase = new End();
                NowPhase.Execute();
            }
            _turnManager.BeginTurn();
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
            _turnManager.SendMove(null, true);
        }
    }
}