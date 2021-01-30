using UnityEngine;
using BladeRondo.Game.Component.CardState;
using BladeRondo.System;

namespace BladeRondo.Game.Component
{    
    public class CardStatus : MonoBehaviour 
    {
        public CardStateType StatusType { get; set; } = CardStateType.None;
        public IState Status { get; set; } = new None();
    }
}