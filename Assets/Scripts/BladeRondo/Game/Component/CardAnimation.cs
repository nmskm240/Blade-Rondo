using UnityEngine;
using UnityEngine.UI;

namespace BladeRondo.Game.Component
{    
    public class CardAnimation : MonoBehaviour 
    {
        private Animator Animator;

        private void Awake() 
        {
            Animator = GetComponent<Animator>();
        }

        private void OnTransformParentChanged() 
        {
            var card = GetComponent<Card>();
            if(this.transform.parent.gameObject.name == "Hand" && card.CanPlay())
            {
                GetComponent<Outline>().enabled = true;
                Animator.SetTrigger("Playable");
            }
            else
            {
                GetComponent<Outline>().enabled = false;
                Animator.ResetTrigger("Playable");
            }
        }
    }
}