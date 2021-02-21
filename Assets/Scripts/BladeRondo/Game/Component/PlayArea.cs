using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using BladeRondo.Network.RaiseEvents;
using BladeRondo.System;

namespace BladeRondo.Game.Component
{    
    public class PlayArea : MonoBehaviourSubject<Card>
    {
        public void Put(GameObject go)
        {
            var cardPhotonView = go.GetComponent<PhotonView>();
            var card = go.GetComponent<Card>();
            card.PayCost();
            cardPhotonView.RPC("ChangeParent", RpcTarget.All, "PlayArea");
            PhotonNetwork.RaiseEvent((byte)RaiseEventType.PlayCard, cardPhotonView.ViewID, new RaiseEventOptions(){ Receivers = ReceiverGroup.Others }, new SendOptions(){ Reliability = true });
            card.ActivateEffect();
        }
    }
}