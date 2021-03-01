using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using BladeRondo.Game;
using BladeRondo.Game.Effect;
using BladeRondo.Game.Effect.Attachable;
using BladeRondo.Network.CustomProperties.Players;

namespace BladeRondo.System
{    
    public class DebugManager : MonoBehaviourPunCallbacks 
    {
        private int _cardID = 0;
        private int _attachEffectCursor = 0;
        private int _detachEffectCursor = 0;
        private List<IEffect> _attachableEffects;
        private bool _isAttached = false;

        private void Awake() 
        {
            _attachableEffects = new List<IEffect>();
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes().Where(p => p.Namespace == "BladeRondo.Game.Effect.Attachable").OrderBy(o => o.Name).Select(s => s);
            foreach(var type in types)
            {
                var effect = Activator.CreateInstance(type) as IEffect;
                _attachableEffects.Add(effect);
            }
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
            GUI.Label(new Rect(0,60,80,20), _attachableEffects[_attachEffectCursor].GetType().Name);
            if(GUI.Button(new Rect(80,60,20,20), ">"))
            {
                _attachEffectCursor = (_attachEffectCursor == _attachableEffects.Count - 1) ? 0 : _attachEffectCursor + 1;
            }
            if(GUI.Button(new Rect(0,80,80,20), "attach me"))
            {
                PhotonNetwork.LocalPlayer.AttachEffect(_attachableEffects[_attachEffectCursor]);
            }
            if(_isAttached)
            {
                GUI.Label(new Rect(0,100,80,20), PhotonNetwork.LocalPlayer.GetAttachedEffects()[_detachEffectCursor].GetType().Name);
                if(GUI.Button(new Rect(80,100,20,20), ">"))
                {
                    _detachEffectCursor = (_detachEffectCursor == PhotonNetwork.LocalPlayer.GetAttachedEffects().Count - 1) ? 0 : _detachEffectCursor + 1;
                }
                if(GUI.Button(new Rect(0,120,80,20), "detach me"))
                {
                    PhotonNetwork.LocalPlayer.DetachEffect(PhotonNetwork.LocalPlayer.GetAttachedEffects()[_detachEffectCursor]);
                }
            }
        }

        public override void OnPlayerPropertiesUpdate(Player player, Hashtable hashtable)
        {
            if(PhotonNetwork.LocalPlayer == player)
            {
                if(hashtable.ContainsKey("AttachedEffect"))
                {
                    _isAttached = player.GetAttachedEffects().Count > 0;
                }
            }
        }
    }
}