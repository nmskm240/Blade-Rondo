using UnityEngine;

namespace BladeRondo.Game.Component
{    
    public class PlayArea : MonoBehaviour
    {
        public void UseCard(GameObject card)
        {
            card.transform.SetParent(this.transform);
        }
    }
}