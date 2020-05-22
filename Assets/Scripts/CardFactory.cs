using System;
using UnityEngine;

public class CardFactory : MonoBehaviour, IFactory
{
    public static CardFactory Instance;
    private string SwordNameSpace = "BladeRondo.Card.SwordCard.";
    private string BreathNamespace = "BladeRondo.Card.BreathCard.";

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public GameObject Create(string id)
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("Prefabs/Card Prefab"));
        obj.AddComponent(Type.GetType(((id.Contains("Sword"))? SwordNameSpace : BreathNamespace) + id));
        obj.GetComponent<CardController>().Init();
        return obj;
    }
}