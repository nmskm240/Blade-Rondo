using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using BladeRondo.Network.CustomProperties.Players;

namespace BladeRondo.Game.Effect
{
    public class AttachEffect : IEffect
    {
        private enum TargetType
        {
            Player,
            Enemy,
        }

        [SerializeReference, SubclassSelector]
        private IEffect _attachEffect;

        [SerializeField]
        private TargetType _target;

        public bool CanActivate()
        {
            return true;
        }

        public void Activate()
        {
            var target = (_target == TargetType.Player) ? PhotonNetwork.LocalPlayer : PhotonNetwork.PlayerListOthers[0];
            target.AttachEffect(_attachEffect);
        }
    }
}