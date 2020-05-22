namespace BladeRondo.Card
{
    using UnityEngine;

    public abstract class Card : MonoBehaviour
    {
        public string Name;
        public string EffectText;
        public int Cost;
        public bool Limited;
        public Sprite Face;
        public abstract bool CanEffect();
        public abstract void Effect();
        public abstract bool CanPlay(int voltage);
        public abstract void Play();
    }
}
