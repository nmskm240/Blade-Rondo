using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FieldShowIf.Enum;

namespace BladeRondo.Game.Component
{    
    [CreateAssetMenu(fileName = "CardData", menuName = "Blade Rondo/CardData", order = 0)]
    public class CardData : ScriptableObject 
    {
        [SerializeField]
        private int id;
        [SerializeField]
        private string name;
        [SerializeField]
        private string abilityText;
        [SerializeField]
        private int cost;
        [SerializeField]
        private bool limited;
        [SerializeField]
        private CardType symbol;
        [SerializeField, ShowChange(nameof(CardType.Magical), nameof(symbol))]
        private int attackPower;
        [SerializeField, ShowChange(nameof(CardType.Trap), nameof(symbol))]
        private List<CardType> responceable;
        [SerializeField]
        private Sprite face;

        public int Id { get { return id; } } 
        public string Name { get { return name; } } 
        public string AbilityText { get { return abilityText; } } 
        public int Cost { get { return cost; } } 
        public bool Limited { get { return limited; } } 
        public CardType Symbol { get { return symbol; } } 
        public int AttackPower { get { return attackPower; } }
        public List<CardType> Responceable { get { return responceable; } }
        public Sprite Face { get { return face; } } 
    }
}