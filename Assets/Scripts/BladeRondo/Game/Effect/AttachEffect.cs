using UnityEngine;

namespace BladeRondo.Game.Effect
{
    public class AttachEffect : IEffect
    {
        private enum Target
        {
            Player,
            Card,
        }

        [SerializeReference, SubclassSelector]
        private IEffect _attachEffect;

        public bool CanActivate()
        {
            return true;
        }

        public void Activate()
        {

        }
    }
}