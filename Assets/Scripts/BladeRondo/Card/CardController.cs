namespace BladeRondo.Card
{
    using UnityEngine;
    using UnityEngine.EventSystems;

    /// <summary>
    /// カードに対する操作全般を管理するクラス
    /// </summary>
    public class CardController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
    {
        public void Init()
        {
            GetComponent<CardView>().ToggleFace(true);
        }

        public void OnBeginDrag(PointerEventData e)
        {
            Debug.Log("begin drag");
        }

        public void OnDrag(PointerEventData e)
        {
            Vector3 TargetPos = Camera.main.ScreenToWorldPoint(e.position);
            TargetPos.z = 0;
            transform.position = TargetPos;
        }

        public void OnEndDrag(PointerEventData e)
        {
            if (e.position.y >= 90)
            {
                transform.SetParent(GameObject.Find("Field").transform);
            }
            else
            {
                transform.SetParent(GameObject.Find("Hand").transform);
            }
        }

        public void OnPointerClick(PointerEventData e)
        {
            Debug.Log("click");
        }
    }
}