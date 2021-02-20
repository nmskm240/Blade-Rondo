using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FieldShowIf.Enum;
using BladeRondo.Game.Effect;
using BladeRondo.System;

namespace BladeRondo.Game.Component
{    
    [CreateAssetMenu(fileName = "CardData", menuName = "Blade Rondo/CardData", order = 0)]
    public class CardData : ScriptableObject 
    {
        [SerializeField]
        private int _id;
        [SerializeField]
        private string _name;
        [SerializeField]
        private string _effectText;
        [SerializeReference, SubclassSelector]
        private List<IEffect> _effects;
        [SerializeField]
        private int _cost;
        [SerializeField]
        private bool _limited;
        [SerializeField]
        private CardType _symbol;
        [SerializeField]
        private bool _canResponce;
        [SerializeField, ShowChange(nameof(CardType.Trap), nameof(_symbol))]
        private List<CardType> _responceable;

        public int ID { get { return _id; } } 
        public string Name { get { return _name; } } 
        public string EffectText { get { return _effectText; } } 
        public IEnumerable<IEffect> Effects { get { return _effects; } }
        public int Cost { get { return _cost; } } 
        public bool Limited { get { return _limited; } } 
        public CardType Symbol { get { return _symbol; } } 
        public bool CanResponce { get { return _canResponce; } }
        public IEnumerable<CardType> Responceable { get { return _responceable; } }
    }
}