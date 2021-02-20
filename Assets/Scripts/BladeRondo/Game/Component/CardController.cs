using UnityEngine;
using UnityEngine.EventSystems;
using Photon.Pun;
using BladeRondo.Network.CustomProperties.Rooms;

namespace BladeRondo.Game.Component
{    
    public class CardController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPunInstantiateMagicCallback
    {
        public void OnBeginDrag(PointerEventData e)
        {
            e.pointerDrag.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData e)
        {
            var card = GetComponent<Card>();
            var photonView = GetComponent<PhotonView>();
            if(card.CanPlay && PhotonNetwork.CurrentRoom.GetTurnPlayer() == PhotonNetwork.LocalPlayer && photonView.IsMine)
            {
                this.transform.position = e.position;
            }
        }

        public void OnEndDrag(PointerEventData e)
        {
            e.pointerDrag.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }

        public void OnPhotonInstantiate(PhotonMessageInfo info)
        {
            var players = GameObject.Find("Players");
            var data = info.photonView.InstantiationData;
            var owner = (info.photonView.IsMine) ? "Player" : "Enemy";
            var card = GetComponent<Card>();
            card.Init(int.Parse((string)data[0]));
            GetComponent<CardView>().Init(card);
            this.transform.SetParent(players.transform.Find(owner).transform.Find("Hand"));
            this.transform.localScale = new Vector3(1,1,1);
        }

        [PunRPC]
        public void ChangeParent(string newParentName)
        {
            var player = this.transform.parent.parent.gameObject;
            var newParent = player.transform.Find(newParentName).gameObject;
            this.transform.SetParent(newParent.transform);
        } 
    }
}