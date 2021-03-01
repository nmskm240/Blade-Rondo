using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using BladeRondo.Game.Component;
using BladeRondo.Network.CustomProperties.Players;

namespace BladeRondo.Game.Effect
{
    public class DiscardPickCard : IEffect
    {
        private enum TargetType
        {
            Player,
            Enemy,
        }

        public bool CanActivate()
        {
            return true;
        }

        public void Activate()
        {

        }
    }
}