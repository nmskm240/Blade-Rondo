using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using BladeRondo.Network.CustomProperties.Players;
using BladeRondo.Network.CustomProperties.Rooms;
using BladeRondo.System;

namespace BladeRondo.Game.Component
{    
    public class PlayArea : MonoBehaviourSubject<Card>
    {
        public void Put(GameObject go)
        {
            var enemy = GameObject.Find("Players").transform.Find("Enemy").gameObject;
            var enemyPlayArea = enemy.transform.Find("PlayArea").gameObject;
            var playAreaPhotonView = enemyPlayArea.GetComponent<PhotonView>();
            var cardPhotonView = go.GetComponent<PhotonView>();
            var card = go.GetComponent<Card>();
            card.PayCost();
            cardPhotonView.RPC("ChangeParent", RpcTarget.All, "PlayArea");
            playAreaPhotonView.RPC("NotifyObservers", RpcTarget.All, card);
        }
    }
}