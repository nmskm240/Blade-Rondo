using UnityEngine;

[CreateAssetMenu(fileName = "CardEntity", menuName = "Blade Rondo/CardEntity", order = 0)]
public class CardEntity : ScriptableObject 
{
        public string Name;
        public string EffectText;
        public int Cost;
        public bool Limited;
        public Sprite Face;
}