namespace BladeRondo.Card.Effects
{
    /// <summary>
    /// 何らかの効果を対象に付与するインターフェイス
    /// </summary>
    public interface IAttachableEffect
    {
        /// <summary>
        /// 付与する効果
        /// </summary>
        void AttachEffect();
    }
}