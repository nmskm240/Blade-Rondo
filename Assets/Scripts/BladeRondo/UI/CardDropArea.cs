using UnityEngine;
using UnityEngine.EventSystems;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using BladeRondo.Game.Component;
using BladeRondo.Network.RaiseEvents;

namespace BladeRondo.UI
{  
    public class CardDropArea : MonoBehaviour, IDropHandler 
    {
        public void OnDrop(PointerEventData e)
        {
            if(e.pointerDrag != null)
            {
                var go = e.pointerDrag;
                var card = go.GetComponent<Card>();
                var photonView = go.GetComponent<PhotonView>();
                if(card.CanPlay())
                {
                    card.PayCost();
                    photonView.RPC("ChangeParent", RpcTarget.All, "PlayArea");
                }
            }
        }
    }
}