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
        private Image Image;
        [SerializeField]
        private Text CardNameText;

        public void ToggleFace(bool IsShow)
        {
            Card card = GetComponent<Card>();
            Image.sprite = Resources.Load<Sprite>("Textures/CardFace");
            CardNameText.text = card.Name;
            //card text load
        }
    }
}