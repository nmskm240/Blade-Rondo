using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using BladeRondo.Game.Component;

namespace BladeRondo.Game.Component
{    
    public class CardView : MonoBehaviour 
    {
        [SerializeField]
        private Text _name;
        [SerializeField]
        private Text _cost;
        [SerializeField]
        private Image _face;
        [SerializeField]
        private Sprite _back;

        public bool IsFaceUp { get { return _face.sprite != _back; } }

        public void Init(Card card)
        {
            _name.text = card.Name;
            _cost.text = card.Cost.ToString();
        }

        public void ToggleFace(bool isFace)
        {
            _face.sprite = (isFace) ? GetComponent<Card>().Face : _back;
            _name.enabled = isFace;
            _cost.enabled = isFace;
        }

        private void OnTransformParentChanged() 
        {
            var photonView = GetComponent<PhotonView>();
            var card = GetComponent<Card>();
            var symbol = card.Symbol;
            var ownerCheck = photonView.IsMine || !card.InHand;
            var trapCheck = card.InHand || symbol != CardType.Trap;
            ToggleFace(ownerCheck && trapCheck); 
        }

    }    
}