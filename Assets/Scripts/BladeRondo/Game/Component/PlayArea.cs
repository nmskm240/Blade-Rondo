using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using BladeRondo.Network.CustomProperties.Players;
using BladeRondo.System;

namespace BladeRondo.Game.Component
{    
    public class PlayArea : MonoBehaviour
    {
        public void Put(GameObject go)
        {
            var photonView = go.GetComponent<PhotonView>();
            var card = go.GetComponent<Card>();
            card.PayCost();
            photonView.RPC("ChangeParent", RpcTarget.All, "PlayArea");
        }
    }
}