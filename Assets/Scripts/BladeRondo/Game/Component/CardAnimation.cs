using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using BladeRondo.Network.CustomProperties.Rooms;

namespace BladeRondo.Game.Component
{    
    public class CardAnimation : MonoBehaviour 
    {
        private Animator _animator;

        private void Awake() 
        {
            _animator = GetComponent<Animator>();
        }

        private void OnTransformParentChanged() 
        {
            var card = GetComponent<Card>();
            var isPlayable = this.transform.parent.gameObject.name == "Hand" && card.CanPlay;
            var isPlayerTurn = PhotonNetwork.CurrentRoom.GetTurnPlayer() == PhotonNetwork.LocalPlayer;
            GetComponent<Outline>().enabled = isPlayable;
            _animator.SetBool("Playable", isPlayable && isPlayerTurn);
        }
    }
}