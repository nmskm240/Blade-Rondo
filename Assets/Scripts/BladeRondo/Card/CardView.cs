namespace BladeRondo.Card
{
    using UnityEngine;
    using UnityEngine.UI;
    using BladeRondo.Card;

    /// <summary>
    /// カードの表裏を管理するクラス
    /// </summary>
    public class CardView : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;
        [SerializeField]
        private Text CardName;
        [SerializeField]
        private Sprite CardFace;
        [SerializeField]
        private Sprite CardBack;

        public void ToggleFace(bool IsShow)
        {
            Card card = GetComponent<Card>();
            spriteRenderer.sprite = (IsShow)? CardFace : CardBack;
            CardName.text = (IsShow)? card.Name : "";
        }
    }
}