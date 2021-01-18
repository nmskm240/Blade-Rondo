using UnityEngine;
using UnityEngine.UI;

namespace BladeRondo.Game.Component
{    
    public class CardView : MonoBehaviour 
    {
        [SerializeField]
        private Image Face;
        [SerializeField]
        private Sprite Back;
        public void ToggleFace(bool isFace)
        {
            Face.sprite = (isFace) ? GetComponent<Card>().Face : Back;
        }
    }    
}