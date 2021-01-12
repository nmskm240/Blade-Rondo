using UnityEngine;
using BladeRondo.Game;

namespace BladeRondo.System
{    
    public class DebugManager : MonoBehaviour 
    {
        private void OnGUI() 
        {
            if(GUI.Button(new Rect(0,0,80,20), "create"))
            {
                new CardFactory().Create("0");
            }    
        }
    }
}