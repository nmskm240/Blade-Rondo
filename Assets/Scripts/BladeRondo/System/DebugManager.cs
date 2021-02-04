using UnityEngine;
using BladeRondo.Game;

namespace BladeRondo.System
{    
    public class DebugManager : MonoBehaviour 
    {
        private int cardId = 0;

        private void OnGUI() 
        {
            GUI.Label(new Rect(0,0,80,20), cardId.ToString());
            if(GUI.Button(new Rect(80,0,20,20), ">"))
            {
                cardId = (cardId == 24) ? 0 : cardId + 1;
            }
            if(GUI.Button(new Rect(0,20,80,20), "card create"))
            {
                new NetworkCardFactory().Create(cardId.ToString());
            }    
        }
    }
}