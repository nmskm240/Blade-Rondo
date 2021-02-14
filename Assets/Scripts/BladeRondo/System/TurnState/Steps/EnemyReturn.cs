using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using BladeRondo.Game.Component;
using BladeRondo.Network.CustomProperties.Players;
using BladeRondo.System;

namespace BladeRondo.System.TurnState.Steps
{
    public class EnemyReturn : IState
    {
        public void Execute()
        {
            var players = GameObject.Find("Players");
            var returnHand = new List<PhotonView>();
            foreach(Transform tf in players.transform.Find("Enemy").transform.Find("PlayArea"))
            {
                var card = tf.gameObject.GetComponent<Card>();
                var cardView = tf.gameObject.GetComponent<CardView>();
                if(!cardView.IsFaceUp)
                {
                    returnHand.Add(tf.gameObject.GetComponent<PhotonView>());
                }
            }
            foreach (var photonView in returnHand)
            {
                photonView.RPC("ChangeParent", RpcTarget.All, "Hand");
            }
        }
    }
}