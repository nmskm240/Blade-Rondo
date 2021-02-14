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

        private IState _nowPhase;

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
            _nowPhase = new FirstPick();
            _nowPhase.Execute();
            yield return new WaitWhile( () => PhotonNetwork.LocalPlayer.GetStartCheck() || PhotonNetwork.PlayerListOthers[0].GetStartCheck() );
            _nowPhase = new BattleSetup();
            _nowPhase.Execute();
            _turnManager.BeginTurn();
        }

        public void OnTurnBegins(int turn)
        {
            if(PhotonNetwork.CurrentRoom.GetTurnPlayer() == PhotonNetwork.LocalPlayer)
            {
                _nowPhase = new Standby();
                _nowPhase.Execute();
                _nowPhase = new Main();
                _nowPhase.Execute();
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
                _nowPhase = new End();
                _nowPhase.Execute();
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