using System;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using BladeRondo.Network.CustomProperties.Players;

namespace BladeRondo.Game.Effect
{
    public class MagicAttack : IEffect
    {
        private enum DamageValueType
        {
            Any,
            FullHP,
            HalfHP,
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
            var damage = 0;
            switch(_damageValueType)
            {
                case DamageValueType.Any:
                    damage = _value;
                    break;
                case DamageValueType.FullHP:
                    damage = defencePlayer.GetHP();
                    break;
                case DamageValueType.HalfHP:
                    damage = defencePlayer.GetHP() / 2;
                    break;
            }
            defencePlayer.AddHP(-1 * damage);
        }
    }
}