using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using BladeRondo.Game;
using BladeRondo.Game.Effect;
using BladeRondo.Network.CustomProperties.Players;

namespace BladeRondo.System
{    
    public class DebugManager : MonoBehaviour 
    {
        private int _cardID = 0;
        private int _effectCursor = 0;
        private List<IEffect> _attachableEffects;

        private void Awake() 
        {
            _attachableEffects = new List<IEffect>()
            {
                new Poison(),
            };
        }

        private void OnGUI() 
        {
            GUI.Label(new Rect(0,0,80,20), _cardID.ToString());
            if(GUI.Button(new Rect(80,0,20,20), ">"))
            {
                _cardID = (_cardID == 24) ? 0 : _cardID + 1;
            }
            if(GUI.Button(new Rect(0,20,80,20), "card create"))
            {
                new NetworkCardFactory().Create(_cardID);
            }
            GUI.Label(new Rect(0,60,80,20), _attachableEffects[_effectCursor].GetType().Name);
            if(GUI.Button(new Rect(80,60,20,20), ">"))
            {
                _effectCursor = (_effectCursor == _attachableEffects.Count - 1) ? 0 : _effectCursor + 1;
            }
            if(GUI.Button(new Rect(0,80,80,20), "attach me"))
            {
                PhotonNetwork.LocalPlayer.AttachEffect(_attachableEffects[_effectCursor]);
            }
        }
    }
}