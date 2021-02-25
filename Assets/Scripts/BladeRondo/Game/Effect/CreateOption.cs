using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BladeRondo.Game;
using BladeRondo.UI;
using BladeRondo.System;

namespace BladeRondo.Game.Effect
{
    public class CreateOption : IEffect
    {
        [SerializeField]
        private List<int> _createCards;
        [SerializeField]
        private int _pickMax;
        [SerializeField]
        private int _pickMin;

        public bool CanActivate()
        {
            return true;
        }

        public void Activate()
        {
            var cardPicker = GameObject.Find("CardPicker").GetComponent<CardPicker>();
            var factory = new LocalCardFactory();
            var cards = new List<GameObject>();
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