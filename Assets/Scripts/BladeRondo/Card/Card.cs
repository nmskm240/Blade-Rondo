namespace BladeRondo.Card
{
    using UnityEngine;

    /// <summary>
    /// Cardの抽象クラス
    /// </summary>
    public abstract class Card : MonoBehaviour
    {
        /// <summary>
        /// カード名
        /// </summary>
        public string Name;

        /// <summary>
        /// カードの効果テキスト
        /// </summary>
        public string EffectText;

        /// <summary>
        /// カードの使用コスト
        /// </summary>
        public int Cost;

        /// <summary>
        /// カードがリミテッドアイコンを持っているかどうか
        /// </summary>
        /// <remarks>持っている：true|持っていない：false</remarks>
        public bool Limited;

        /// <summary>
        /// カードの表面
        /// </summary>
        public Sprite Face;

        /// <summary>
        /// カードの効果の発動確認
        /// </summary>
        /// <remarks>発動可能：true|発動不可：false</remarks>
        /// <returns>発動可能かどうか</returns>
        public abstract bool CanEffect();

        /// <summary>
        /// カードの効果処理
        /// </summary>
        public abstract void Effect();

        /// <summary>
        /// カードが使用可能かの確認
        /// </summary>
        /// <remarks>使用可能：true|使用不可：false</remarks>
        /// <param name="playerVoltage">使用プレイヤーのボルテージ</param>
        /// <returns>使用可能かどうか</returns>
        public abstract bool CanPlay(int playerVoltage);

        /// <summary>
        /// カード使用時の処理
        /// </summary>
        public abstract void Play();
    }
}
