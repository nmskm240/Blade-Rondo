using System;
namespace BladeRondo.System
{
    using UnityEngine;
    using BladeRondo.Card;
    using Photon.Pun;
    using Photon.Realtime;

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
            GameObject obj = PhotonNetwork.Instantiate("Prefabs/Card Prefab", new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
            obj.AddComponent(Type.GetType(((id.Contains("Sword")) ? SwordNameSpace : BreathNamespace) + id));
            obj.GetComponent<CardController>().Init();
            return obj;
        }
    }
}