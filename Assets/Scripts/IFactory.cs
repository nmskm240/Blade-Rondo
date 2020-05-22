using UnityEngine;

public interface IFactory
{
    GameObject Create(string id);
}