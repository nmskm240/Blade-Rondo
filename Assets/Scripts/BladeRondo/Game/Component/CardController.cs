using UnityEngine;
using UnityEngine.EventSystems;
using Photon.Pun;

namespace BladeRondo.Game.Component
{    
    public class CardController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPunInstantiateMagicCallback
    {
        public Vector3 DragBeforePos { get; private set; }
        private GameObject Players;
        private Card Card;

        private void Awake() 
        {
            Players = GameObject.Find("Players");   
            Card = GetComponent<Card>();
        }

        public void OnBeginDrag(PointerEventData e)
        {
            e.pointerDrag.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData e)
        {
            if(Card.CanPlay())
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
            var data = info.photonView.InstantiationData;
            var owner = (info.photonView.IsMine) ? "Player" : "Enemy";
            var place = ((bool)data[1]) ? "Hand" : "PlayArea";
            var card = GetComponent<Card>();
            card.Init(int.Parse((string)data[0]));
            GetComponent<CardView>().Init(card);
            this.transform.SetParent(Players.transform.Find(owner).transform.Find(place));
            this.transform.localScale = new Vector3(1,1,1);
            DragBeforePos = this.transform.position;
        }

        private void OnTransformParentChanged() 
        {
            var photonView = GetComponent<PhotonView>();
            var card = GetComponent<Card>();
            var symbol = card.Symbol;
            var cardView = GetComponent<CardView>();
            var ownerCheck = photonView.IsMine || !card.InHand;
            var trapCheck = card.InHand || symbol != CardType.Trap;
            cardView.ToggleFace(ownerCheck && trapCheck); 
        }
    }
}