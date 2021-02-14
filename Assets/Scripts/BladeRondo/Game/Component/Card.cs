using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using BladeRondo.Game.Effect;
using BladeRondo.Network.CustomProperties.Players;
using BladeRondo.System;

namespace BladeRondo.Game.Component
{    
    public class Card : MonoBehaviour 
    {
        private int _cost;

        public int ID { get; private set; }
        public string Name { get; private set; }
        public string EffectText { get; private set; }
        public EffectTiming EffectTiming { get; private set; }
        public IEnumerable<IEffect> Effects { get; private set; }
        public int Cost { get { return ( _cost == -1) ? PhotonNetwork.LocalPlayer.GetNowVoltage() : _cost; } private set { _cost = value; } }
        public bool Limited { get; private set; }
        public CardType Symbol { get; private set; }
        public int AttackPower { get; private set; }
        public bool CanResponce { get; private set; }
        public IEnumerable<CardType> Responceable { get; private set; }
        public Sprite Face { get; private set; }
        public bool InHand { get { return this.transform.parent.gameObject.name == "Hand"; } }
        public bool CanPlay { get { return PhotonNetwork.LocalPlayer.GetNowVoltage() >= Cost; } }

        public void Init(int id)
        {
            var data = Resources.Load("Data/" + id.ToString()) as CardData;
            ID = data.ID;
            Name = data.Name;
            EffectText = data.EffectText;
            EffectTiming = data.EffectTiming;
            Effects = data.Effects;
            Cost = data.Cost;
            Limited = data.Limited;
            Symbol = data.Symbol;
            AttackPower = data.AttackPower;
            CanResponce = data.CanResponce;
            Responceable = data.Responceable;
            var face = Resources.Load("Textures/" + id.ToString(), typeof(Sprite)) as Sprite;
            Face = (face == null) ? Resources.Load("Textures/CardFace", typeof(Sprite)) as Sprite : face;
        }

        public void PayCost()
        {
            var voltage = PhotonNetwork.LocalPlayer.GetNowVoltage();
            PhotonNetwork.LocalPlayer.SetNowVoltage(voltage - Cost);
        }

        public void ActivateEffect()
        {
            foreach(var effect in Effects)
            {
                effect.Activate();
            }
        }
    }
}