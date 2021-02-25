using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using BladeRondo.Game;
using BladeRondo.Network.CustomProperties.Rooms;
using BladeRondo.UI;

namespace BladeRondo.System.TurnState.Phases
{
    public class FirstPick : IState
    {
        public void Execute()
        {
            var deck = PhotonNetwork.CurrentRoom.GetDeck();
            var cards = new List<GameObject>();
            var cardFactory = new LocalCardFactory(); 
            var cardPicker = GameObject.Find("MoveUI").transform.Find("CardPicker").gameObject.GetComponent<CardPicker>();
            for(int i = 0; i < 15; i++)
            {
                var target = (PhotonNetwork.IsMasterClient) ? i : (deck.Count - 1) - i;
                cards.Add(cardFactory.Create(deck[target]));
            }
            cardPicker.SetOptions(cards);
            cardPicker.SetPickMinAndMax(7, 7);
            cardPicker.Show();
        }
    }
}