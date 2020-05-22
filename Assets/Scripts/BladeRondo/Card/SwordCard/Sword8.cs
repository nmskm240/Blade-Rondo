namespace BladeRondo.Card.SwordCard
{
    using UnityEngine;
    using BladeRondo.Card;
    using BladeRondo.Card.Effects;

    public class Sword8 : Card, IMagicalAttacker
    {
        void Awake()
        {
            CardEntity c = Resources.Load<CardEntity>("Card/Sword8");
            this.Name = c.Name;
            this.EffectText = c.EffectText;
            this.Cost = c.Cost;
            this.Limited = c.Limited;
            this.Face = c.Face;
        }

        public override bool CanEffect()
        {
            return false;
        }

        public override void Effect()
        {
            ;
        }

        public override bool CanPlay(int volage)
        {
            return (this.Cost >= volage)? true : false;
        }

        public override void Play()
        {

        }

        public void MagicalAttack()
        {
            
        }
    }
}