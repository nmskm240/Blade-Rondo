using UnityEngine;

namespace BladeRondo.Game.Effect.Attachable
{
    public class Poison : IEffect
    {
        public bool CanActivate()
        {
            return true;
        }

        public void Activate()
        {
            Debug.Log("Poison!");
        }
    }
}