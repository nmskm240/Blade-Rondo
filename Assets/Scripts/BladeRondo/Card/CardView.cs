namespace BladeRondo.Card
{
    using UnityEngine;
    using BladeRondo.Card;

    /// <summary>
    /// カードの表裏を管理するクラス
    /// </summary>
    public class CardView : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer sp;

        public void ToggleFace(bool IsShow)
        {
            sp.sprite = GetComponent<Card>().Face;
        }
    }
}