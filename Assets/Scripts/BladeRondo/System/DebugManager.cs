using UnityEngine;
using BladeRondo.Game;

namespace BladeRondo.System
{    
    public class DebugManager : MonoBehaviour 
    {
        private int _cardId = 0;

        private void OnGUI() 
        {
            GUI.Label(new Rect(0,0,80,20), _cardId.ToString());
            if(GUI.Button(new Rect(80,0,20,20), ">"))
            {
                _cardId = (_cardId == 24) ? 0 : _cardId + 1;
            }
            if(GUI.Button(new Rect(0,20,80,20), "card create"))
            {
                new NetworkCardFactory().Create(_cardId);
            }    
        }
    }
}