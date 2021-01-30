using UnityEngine;
using Photon.Pun;
using BladeRondo.Game.Component;
using BladeRondo.System;

namespace BladeRondo.Game
{
    public class CardFactory : Object, IFactory<GameObject>
    {
        public GameObject Create(string id, bool isHand)
        {
            object[] data = { (object)id, (object)isHand };
            var go = PhotonNetwork.Instantiate("Prefabs/CardPrefab", new Vector3(0, 0, 0), Quaternion.identity, 0, data);
            return go;
        }
    }
}