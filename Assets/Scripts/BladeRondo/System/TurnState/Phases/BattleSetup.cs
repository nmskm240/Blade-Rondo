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
    public class BattleSetup : IState
    {
        private List<int> FirstsBreathCards = new List<int>()
        {
            0,1
        };

        private List<int> SecondsBreathCards = new List<int>()
        {
            0,1,2
        };

        public void Execute()
        {
            var cardFactory = new NetworkCardFactory();
            var players = GameObject.Find("Players");
            var hand = players.transform.Find("Player").transform.Find("Hand").gameObject;
            var startPlayer = PhotonNetwork.CurrentRoom.GetTurnPlayer();

            foreach(var id in PhotonNetwork.LocalPlayer.GetHand())
            {
                var card = cardFactory.Create(id.ToString());
                card.transform.SetParent(hand.transform);
            }
            foreach(var id in (startPlayer == PhotonNetwork.LocalPlayer) ? FirstsBreathCards : SecondsBreathCards)
            {
                var card = cardFactory.Create(id.ToString());
                card.transform.SetParent(hand.transform);
            }
            PhotonNetwork.LocalPlayer.SetHP(15);
            PhotonNetwork.LocalPlayer.SetMaxVoltage(0);
            PhotonNetwork.LocalPlayer.SetNowVoltage(0);
            PhotonNetwork.LocalPlayer.SetAttack((startPlayer == PhotonNetwork.LocalPlayer) ? 0 : 1);
            PhotonNetwork.LocalPlayer.SetDefence(0);
        }
    }
}