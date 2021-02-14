namespace BladeRondo.Game.Effect
{
    public interface IEffect
    {
        bool CanActivate();
        void Activate();
    }
}