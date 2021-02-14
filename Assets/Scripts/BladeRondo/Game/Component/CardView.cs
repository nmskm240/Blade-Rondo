using UnityEngine;
using UnityEngine.UI;
using BladeRondo.Game.Component;

namespace BladeRondo.Game.Component
{    
    public class CardView : MonoBehaviour 
    {
        [SerializeField]
        private GameObject _faceInfo;
        [SerializeField]
        private Image _face;
        [SerializeField]
        private Sprite _back;

        public bool IsFaceUp { get { return _face.sprite != _back; } }

        public void Init(Card card)
        {
            _faceInfo.transform.Find("Name").gameObject.GetComponent<Text>().text = card.Name;
            _faceInfo.transform.Find("Cost").transform.Find("Text").gameObject.GetComponent<Text>().text = card.Cost.ToString();
        }

        public void ToggleFace(bool isFace)
        {
            _face.sprite = (isFace) ? GetComponent<Card>().Face : _back;
            _faceInfo.SetActive(isFace);
        }
    }    
}