using System;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using BladeRondo.Network.CustomProperties.Players;

namespace BladeRondo.Game.Effect
{
    [Serializable]
    public class AddHP : IEffect
    {
        [SerializeField]
        private int _value;

        public bool CanActivate()
        {
            return true;
        }

        public void Activate()
        {
            PhotonNetwork.LocalPlayer.AddHP(_value);
        }
    }
}