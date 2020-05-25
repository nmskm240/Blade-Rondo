namespace BladeRondo.Card.Effects
{
    /// <summary>
    /// 同一ターンで二回使用を可能にするインターフェイス
    /// </summary>
    public interface IReusable
    {
        void Reuse();
    }
}