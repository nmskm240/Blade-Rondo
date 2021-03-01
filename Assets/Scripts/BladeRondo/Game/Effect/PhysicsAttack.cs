using System;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using BladeRondo.Network.CustomProperties.Players;

namespace BladeRondo.Game.Effect
{
    public class PhysicsAttack : IEffect
    {
        private enum DamageValueType
        {
            Any,
            Fixed,
            IgnoreDefence,
        }

        [SerializeField]
        private int _value;
        [SerializeField]
        private DamageValueType _damageValueType;

        public bool CanActivate()
        {
            return true;
        }

        public void Activate()
        {
            var attackPlayer = PhotonNetwork.LocalPlayer; 
            var defencePlayer = PhotonNetwork.PlayerListOthers[0];
            var attackPower = 0;
            var defencePower = defencePlayer.GetDefence();
            var damage = 0;
            switch(_damageValueType)
            {
                case DamageValueType.Any:
                    attackPower = attackPlayer.GetAttack();
                    break;
                case DamageValueType.Fixed:
                    attackPower = _value;
                    break;
                case DamageValueType.IgnoreDefence:
                    attackPower = attackPlayer.GetAttack();
                    defencePower = 0;
                    break;
            }
            damage = (attackPower - defencePower) < 0 ? 0 : attackPower - defencePower;
            defencePlayer.AddHP(-1 * damage);
        }
    }
}