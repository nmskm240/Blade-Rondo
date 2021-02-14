using UnityEngine;
using UnityEngine.UI;

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
            var playable = this.transform.parent.gameObject.name == "Hand" && card.CanPlay;
            GetComponent<Outline>().enabled = playable;
            _animator.SetBool("Playable", playable);
        }
    }
}