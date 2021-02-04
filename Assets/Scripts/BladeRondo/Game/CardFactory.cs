using UnityEngine;
using Photon.Pun;
using BladeRondo.Game.Component;
using BladeRondo.System;

namespace BladeRondo.Game
{
    public class NetworkCardFactory : Object, IFactory<GameObject>
    {
        public GameObject Create(string id)
        {
            object[] data = { (object)id };
            var go = PhotonNetwork.Instantiate("Prefabs/CardPrefab", new Vector3(0, 0, 0), Quaternion.identity, 0, data);
            return go;
        }
    }

    public class LocalCardFactory : Object, IFactory<GameObject>
    {
        public GameObject Create(string id)
        {
            var go = Instantiate(Resources.Load("Prefabs/CardPrefab") as GameObject);
            var card = go.GetComponent<Card>();
            card.Init(int.Parse(id));
            go.GetComponent<CardView>().Init(card);
            return go;
        }
    }
}