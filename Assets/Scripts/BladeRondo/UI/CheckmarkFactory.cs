using UnityEngine;
using UnityEngine.UI;
using BladeRondo.System;

namespace BladeRondo.UI
{
    public class CheckmarkFactory : Object, IFactory<GameObject>
    {
        public GameObject Create(int i = 0)
        {
            var go = Instantiate(Resources.Load("Prefabs/AttachedEffectIconPrefab") as GameObject);
            go.GetComponent<Image>().sprite = Resources.Load("Textures/Checkmark", typeof(Sprite)) as Sprite;
            return go;
        }
    }
}