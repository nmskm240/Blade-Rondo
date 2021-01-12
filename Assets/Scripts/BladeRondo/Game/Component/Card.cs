using UnityEngine;
using UnityEngine.UI;
using BladeRondo.System;

namespace BladeRondo.Game.Component
{    
    public class Card : MonoBehaviour 
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string AbilityText { get; private set; }
        public int Cost { get; private set; }
        public bool Limited { get; private set; }
        public CardType Symbol { get; private set; }
        public Sprite Face { get; private set; }
        public CardStateType StatusType { get; private set; }
        public IState Status { get; private set; }

        public delegate void Ability();
        public delegate bool Check();

        public Ability Abilities;
        public Check CanPlay;
        public Check CanActivateAbility;

        public void Init(int id)
        {
            var data = Resources.Load("Data/" + id.ToString()) as CardData;
            Id = data.Id;
            Name = data.Name;
            AbilityText = data.AbilityText;
            Cost = data.Cost;
            Limited = data.Limited;
            Symbol = data.Symbol;
            Face = data.Face;
        }
    }
}