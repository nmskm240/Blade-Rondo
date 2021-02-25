using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using BladeRondo.Game.Component;

namespace BladeRondo.Game.Component
{    
    public class CardView : MonoBehaviour 
    {
        [SerializeField]
        private GameObject _cardDetail;
        [SerializeField]
        private Image _face;
        [SerializeField]
        private Sprite _back;

        public bool IsFaceUp { get { return _face.sprite != _back; } }

        public void Init(Card card)
        {
            var name = _cardDetail.transform.Find("Name").gameObject.GetComponent<Text>();
            var icon = _cardDetail.transform.Find("Icon").gameObject.GetComponent<Image>();
            var cost = _cardDetail.transform.Find("Cost").transform.Find("Text").gameObject.GetComponent<Text>();
            var limited = _cardDetail.transform.Find("Limited").gameObject.GetComponent<Image>();
            name.text = card.Name;
            icon.sprite = Resources.Load("Textures/Card/Icon/" + card.Symbol.ToString(), typeof(Sprite)) as Sprite;
            cost.text = card.Cost.ToString();
            limited.enabled = card.Limited;
        }

        public void ToggleFace(bool isFace)
        {
            _face.sprite = (isFace) ? GetComponent<Card>().Face : _back;
            _cardDetail.SetActive(isFace);
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