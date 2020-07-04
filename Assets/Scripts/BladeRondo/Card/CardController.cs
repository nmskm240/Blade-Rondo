using System;
namespace BladeRondo.Card
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.EventSystems;
    using Photon.Pun;
    using Photon.Realtime;

    /// <summary>
    /// カードに対する操作全般を管理するクラス
    /// </summary>
    public class CardController : MonoBehaviour, IPunObservable, IPunInstantiateMagicCallback, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
    {
        private Vector2 HandBackPos;

        public void Init()
        {
            GetComponent<CardView>().ToggleFace(GetComponent<PhotonView>().IsMine);
        }

        public void ReturnHand()
        {
            if(GetComponent<Card>().Limited)
            {
                PhotonNetwork.Destroy(gameObject);
            }
            else
            {
                transform.SetParent(transform.parent.parent.transform.Find("Hand"));
            }
        }

        public void OnBeginDrag(PointerEventData e)
        {
            HandBackPos = transform.position;
        }

        public void OnDrag(PointerEventData e)
        {
            Vector3 TargetPos = Camera.main.ScreenToWorldPoint(e.position);
            TargetPos.z = 0;
            transform.position = TargetPos;
        }

        public void OnEndDrag(PointerEventData e)
        {
            if (e.position.y >= 90 && transform.parent.gameObject.name == "Hand")
            {
                transform.SetParent(this.transform.parent.parent.transform.Find("Field"));
            }
            else
            {
                transform.position = HandBackPos;
            }
        }

        public void OnPointerClick(PointerEventData e)
        {
            Debug.Log("click");
        }

        public void OnPhotonInstantiate(PhotonMessageInfo Info)
        {
            bool IsMine = GetComponent<PhotonView>().IsMine;
            transform.SetParent(GameObject.Find((IsMine) ? "Player" : "Enemy").transform.Find("Hand"));
            this.enabled = IsMine;
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(this.transform.parent.gameObject.name);
                stream.SendNext(GetComponent<Card>().GetType().ToString());
            }
            else
            {
                string parent = (string)stream.ReceiveNext();
                if (!parent.Equals(this.transform.parent.gameObject.name))
                {
                    this.transform.SetParent(GameObject.Find("Enemy").transform.Find(parent));
                    this.gameObject.AddComponent(Type.GetType((string)stream.ReceiveNext()));
                    GetComponent<CardView>().ToggleFace(true);
                }
                else
                {
                    stream.ReceiveNext();
                }
            }
        }
    }
}