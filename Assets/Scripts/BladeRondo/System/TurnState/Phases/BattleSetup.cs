using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using BladeRondo.Game;
using BladeRondo.Network.CustomProperties.Players;
using BladeRondo.Network.CustomProperties.Rooms;
using BladeRondo.System;

namespace BladeRondo.System.TurnState.Phases
{
    public class BattleSetup : Object ,IState
    {
        public void Execute()
        {
            var cardFactory = new NetworkCardFactory();
            var players = GameObject.Find("Players");
            var hand = players.transform.Find("Player").transform.Find("Hand").gameObject;
            var startPlayerId = Random.Range(0,2);
            var stratPlayer = PhotonNetwork.PlayerList[startPlayerId];
            foreach(var id in PhotonNetwork.LocalPlayer.GetHand())
            {
                var card = cardFactory.Create(id.ToString());
                card.transform.SetParent(hand.transform);
            }
            PhotonNetwork.CurrentRoom.SetTurnPlayer(stratPlayer);
            PhotonNetwork.LocalPlayer.SetHP(15);
            PhotonNetwork.LocalPlayer.SetMaxVoltage(0);
            PhotonNetwork.LocalPlayer.SetNowVoltage(0);
            PhotonNetwork.LocalPlayer.SetAttack((stratPlayer == PhotonNetwork.LocalPlayer) ? 0 : 1);
            PhotonNetwork.LocalPlayer.SetDefence(0);
        }
    }
}