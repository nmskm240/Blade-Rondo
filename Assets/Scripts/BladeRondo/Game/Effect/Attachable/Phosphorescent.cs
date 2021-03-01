using UnityEngine;

namespace BladeRondo.Game.Effect.Attachable
{
    public class Phosphorescent : IEffect
    {
        public bool CanActivate()
        {
            return true;
        }

        public void Activate()
        {
            Debug.Log("燐光");
        }
    }
}