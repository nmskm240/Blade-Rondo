using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BladeRondo.Game;
using BladeRondo.UI;

namespace BladeRondo.System.TurnState.Phases
{
    public class FirstPick : Object, IState
    {
        public void Execute()
        {
            var cards = new List<GameObject>();
            var cardFactory = new LocalCardFactory(); 
            var cardPicker = GameObject.Find("MoveUI").transform.Find("CardPicker").gameObject.GetComponent<CardPicker>();
            for(int i = 0; i < 15; i++)
            {
                cards.Add(cardFactory.Create(i.ToString()));
            }
            cardPicker.SetOptions(cards);
            cardPicker.Show();
        }
    }
}