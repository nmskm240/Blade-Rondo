using System;
namespace BladeRondo.System
{
    using UnityEngine;
    using BladeRondo.Card;

    /// <summary>
    /// カードを作成するクラス
    /// </summary>
    public class CardFactory : MonoBehaviour, IFactory
    {
        public static CardFactory Instance;
        private string SwordNameSpace = "BladeRondo.Card.SwordCard.";
        private string BreathNamespace = "BladeRondo.Card.BreathCard.";

        void OnEnable()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        void OnDisable()
        {
            if (Instance != null)
            {
                Instance = null;
            }
        }

        /// <summary>
        /// カードを作成する
        /// </summary>
        /// <param name="id">カードID</param>
        /// <returns>作成されたカードオブジェクト</returns>
        public GameObject Create(string id)
        {
            GameObject obj = Instantiate(Resources.Load<GameObject>("Prefabs/Card Prefab"));
            obj.AddComponent(Type.GetType(((id.Contains("Sword")) ? SwordNameSpace : BreathNamespace) + id));
            obj.GetComponent<CardController>().Init();
            return obj;
        }
    }
}