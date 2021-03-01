using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using BladeRondo.Game;
using BladeRondo.Game.Component;
using BladeRondo.UI;
using BladeRondo.Network.CustomProperties.Players;
using BladeRondo.System;

namespace BladeRondo.Game.Effect
{
    public class CreateOption : IEffect
    {
        private enum PickOptionsType
        {
            HandAll,
            PickCards,
            Lists,
        }
        private enum TargetType
        {
            Player,
            Enemy,
        }

        [SerializeField]
        private List<int> _createCards;
        [SerializeField]
        private int _pickMax;
        [SerializeField]
        private int _pickMin;
        [SerializeField]
        private PickOptionsType _pickOption;
        [SerializeField]
        private TargetType _target;

        public bool CanActivate()
        {
            return true;
        }

        public void Activate()
        {
            var cardPicker = GameObject.Find("MoveUI").transform.Find("CardPicker").gameObject.GetComponent<CardPicker>();
            var factory = new LocalCardFactory();
            var cards = new List<GameObject>();
            if(_pickOption == PickOptionsType.HandAll)
            {
                var player = GameObject.Find(_target.ToString());
                var hand = player.transform.Find("Hand").gameObject;
                _createCards.Clear();
                foreach(Transform tf in hand.transform)
                {
                    var cardID = tf.gameObject.GetComponent<Card>().ID;
                    _createCards.Add(cardID);
                }
            }
            else if(_pickOption == PickOptionsType.PickCards)
            {
                var player = (_target == TargetType.Player) ? PhotonNetwork.LocalPlayer : PhotonNetwork.PlayerListOthers[0];
                _createCards.Clear();
                foreach(var cardID in player.GetPickCards())
                {
                    _createCards.Add(cardID);
                }
            }
            foreach(var id in _createCards)
            {
                var card = factory.Create(id);
                cards.Add(card);
            }
            cardPicker.SetOptions(cards);
            cardPicker.SetPickMinAndMax(_pickMin, _pickMax);
            cardPicker.Show();
        }
    }
}