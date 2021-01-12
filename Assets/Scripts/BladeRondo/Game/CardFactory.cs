using UnityEngine;
using BladeRondo.Game.Component;
using BladeRondo.System;

namespace BladeRondo.Game
{
    public class CardFactory : Object, IFactory<GameObject>
    {
        public GameObject Create(string id)
        {
            var go = Instantiate(Resources.Load("Prefabs/CardPrefab") as GameObject);
            go.GetComponent<Card>().Init(int.Parse(id));
            return go;
        }
    }
}