using UnityEngine;
using UnityEngine.UI;

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
        [SerializeField]
        private Sprite face;

        public int Id { get { return id; } } 
        public string Name { get { return name; } } 
        public string AbilityText { get { return abilityText; } } 
        public int Cost { get { return cost; } } 
        public bool Limited { get { return limited; } } 
        public CardType Symbol { get { return symbol; } } 
        public Sprite Face { get { return face; } } 
    }
}