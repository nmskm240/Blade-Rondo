using UnityEngine;
using UnityEngine.EventSystems;

namespace BladeRondo.Game.Component
{    
    public class CardController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public void OnBeginDrag(PointerEventData e)
        {
            e.pointerDrag.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData e)
        {
            this.transform.position = e.position;
        }

        public void OnEndDrag(PointerEventData e)
        {
            e.pointerDrag.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }
}