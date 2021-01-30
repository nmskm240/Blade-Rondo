using UnityEngine;
using UnityEngine.UI;
using BladeRondo.Game.Component;

namespace BladeRondo.Game.Component
{    
    public class CardView : MonoBehaviour 
    {
        [SerializeField]
        private GameObject FaceInfo;
        [SerializeField]
        private Image Face;
        [SerializeField]
        private Sprite Back;

        public void Init(Card card)
        {
            FaceInfo.transform.Find("Name").gameObject.GetComponent<Text>().text = card.Name;
            FaceInfo.transform.Find("Cost").transform.Find("Text").gameObject.GetComponent<Text>().text = card.Cost.ToString();
        }

        public void ToggleFace(bool isFace)
        {
            Face.sprite = (isFace) ? GetComponent<Card>().Face : Back;
            FaceInfo.SetActive(isFace);
        }
    }    
}