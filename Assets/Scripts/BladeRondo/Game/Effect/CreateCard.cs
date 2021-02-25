using UnityEngine;
using BladeRondo.System;

namespace BladeRondo.Game.Effect
{
    public class CreateCard : IEffect
    {
        [SerializeField]
        private int _summonId;

        public bool CanActivate()
        {
            return true;
        }

        public void Activate()
        {
            var factory = new NetworkCardFactory();
            var card = factory.Create(_summonId);
            var player = GameObject.Find("Players").transform.Find("Player").gameObject;
            card.transform.SetParent(player.transform.Find("Hand"));
        }
    }
}