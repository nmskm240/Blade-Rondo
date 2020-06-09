namespace BladeRondo.Card
{
        using UnityEngine;

        [CreateAssetMenu(fileName = "CardEntity", menuName = "Blade Rondo/CardEntity", order = 0)]
        /**
        <summary>
        カード情報をUnityで管理するためのコード
        <summary>
        */
        public class CardEntity : ScriptableObject 
        {
                public string Name;
                public string EffectText;
                public int Cost;
                public bool Limited;
        }
}
