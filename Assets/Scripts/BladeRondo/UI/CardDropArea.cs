using UnityEngine;
using UnityEngine.EventSystems;
using BladeRondo.Game.Component;

namespace BladeRondo.UI
{  
    public class CardDropArea : MonoBehaviour, IDropHandler 
    {
        [SerializeField]
        private GameObject PlayArea;

        public void OnDrop(PointerEventData e)
        {
            if(e.pointerDrag != null)
            {
                PlayArea.GetComponent<PlayArea>().UseCard(e.pointerDrag);
            }
        }
    }
}