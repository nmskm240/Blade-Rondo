using UnityEngine;

namespace BladeRondo.Game.Component
{    
    public class PlayArea : MonoBehaviour
    {
        public void Put(GameObject card)
        {
            card.transform.SetParent(this.transform);
        }
    }
}