using UnityEngine;
using UnityEngine.EventSystems;
using BladeRondo.Game.Component;

namespace BladeRondo.UI
{  
    public class CardDropArea : MonoBehaviour, IDropHandler 
    {
        [SerializeField]
        private PlayArea PlayArea;

        public void OnDrop(PointerEventData e)
        {
            if(e.pointerDrag != null)
            {
                var go = e.pointerDrag;
                var card = go.GetComponent<Card>();
                if(card.CanPlay)
                {
                    PlayArea.Put(go);
                }
            }
        }
    }
}