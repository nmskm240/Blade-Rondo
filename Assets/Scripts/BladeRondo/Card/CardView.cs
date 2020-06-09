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

        public void ToggleFace(bool IsShow)
        {
            Card card = GetComponent<Card>();
            spriteRenderer.sprite = Resources.Load<Sprite>("Textures/CardFace");
            CardName.text = card.Name;
            //card text load
        }
    }
}