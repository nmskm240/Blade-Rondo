using UnityEngine;

namespace BladeRondo.Game.Effect
{
    public class AttachEffect : IEffect
    {
        private enum TargetType
        {
            Player,
            Card,
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

        }
    }
}