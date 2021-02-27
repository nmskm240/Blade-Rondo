using UnityEngine;

namespace BladeRondo.Game.Effect
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