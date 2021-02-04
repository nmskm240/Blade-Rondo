using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;
using BladeRondo.Game.Component;
using BladeRondo.Network.CustomProperties.Players;
using BladeRondo.Network.CustomProperties.Rooms;
using BladeRondo.System.TurnState.Phases;

namespace BladeRondo.System
{    
    public class TurnManager : MonoBehaviour, IPunTurnManagerCallbacks 
    {
        [SerializeField]
        private PunTurnManager turnManager;
        [SerializeField]
        private GameObject Players;

        private IState NowPhase;

        private void Awake() 
        {
            turnManager.TurnManagerListener = this;
        }

        private IEnumerator Start()
        {
            NowPhase = new FirstPick();
            NowPhase.Execute();
            yield return new WaitWhile( () => PhotonNetwork.LocalPlayer.GetStartCheck() || PhotonNetwork.PlayerListOthers[0].GetStartCheck() );
            NowPhase = new BattleSetup();
            NowPhase.Execute();
            if(PhotonNetwork.IsMasterClient)
            {
                turnManager.BeginTurn();
            }
        }

        public void OnTurnBegins(int turn)
        {
            if(PhotonNetwork.CurrentRoom.GetTurnPlayer() == PhotonNetwork.LocalPlayer)
            {
                NowPhase = new Standby();
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
                var nextPlayer = PhotonNetwork.CurrentRoom.GetTurnPlayer().GetNext();
                PhotonNetwork.CurrentRoom.SetTurnPlayer(nextPlayer);
            }
            turnManager.BeginTurn();
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
            // var photonViews = new List<PhotonView>();
            // foreach(Transform tf in Players.transform.Find("Player").transform.Find("PlayArea"))
            // {
            //     var card = tf.gameObject.GetComponent<Card>();
            //     var cardView = tf.gameObject.GetComponent<CardView>();
            //     if(cardView.IsShowFace && !card.Limited)
            //     {
            //         photonViews.Add(tf.gameObject.GetComponent<PhotonView>());
            //     }
            // }
            // foreach (var photonView in photonViews)
            // {
            //     photonView.RPC("ChangeParent", RpcTarget.All, "Hand");
            // }
            turnManager.SendMove(null, true);
        }
    }
}