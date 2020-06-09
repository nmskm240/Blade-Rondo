namespace BladeRondo.Card
{
    using UnityEngine;
    using BladeRondo.Card.State;

    public class CardStatus : MonoBehaviour
    {
        public ICardState Status = new Unplayable();
    }
}