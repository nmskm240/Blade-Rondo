using UnityEngine;
using BladeRondo.System;

public class GameManager : MonoBehaviour 
{
    int Id = 1;

    void OnGUI()
    {
        GUI.Label(new Rect(0, 75, 50, 25),"Sword" + Id);

        if(GUI.Button(new Rect(0, 100, 25, 25),"◀"))
        {
            Id = (Id <= 1)? 20 : Id - 1;
        }

		if(GUI.Button(new Rect(25, 100, 50, 25),"Create"))
        {
            GameObject obj = CardFactory.Instance.Create("Sword" + Id);
            obj.transform.SetParent(GameObject.Find("Hand").transform);
            obj.transform.localRotation = new Quaternion(0, 0, 0, 0);
        }

        if(GUI.Button(new Rect(75, 100, 25, 25),"▶"))
        {
            Id = (Id >= 20)? 1 : Id + 1;
        }
    }    
}