using UnityEngine;
using BladeRondo.Card;

public class CardView : MonoBehaviour 
{
    [SerializeField]
    private SpriteRenderer sp;

    public void ToggleFace(bool IsShow)
    {
        sp.sprite = GetComponent<Card>().Face;
    }
}