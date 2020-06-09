namespace BladeRondo.Card.State
{
    /// <summary>
    /// 効果発動済みや攻撃済みなどのカードの状態に関するステータスを扱うインターフェイス
    /// </summary>
    public interface ICardState
    {
        void Execute();
    }
}