using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using BladeRondo.Network.CustomProperties.Players;
using BladeRondo.System;

namespace BladeRondo.Game.Component
{    
    public class Card : MonoBehaviour 
    {
        private int cost;

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string EffectText { get; private set; }
        public EffectTiming EffectTiming { get; private set; }
        public int Cost { get { return ( cost == -1) ? PhotonNetwork.LocalPlayer.GetNowVoltage() : cost; } private set { cost = value; } }
        public bool Limited { get; private set; }
        public CardType Symbol { get; private set; }
        public int AttackPower { get; private set; }
        public bool CanResponce { get; private set; }
        public List<CardType> Responceable { get; private set; }
        public Sprite Face { get; private set; }
        public bool InHand { get { return this.transform.parent.gameObject.name == "Hand"; } }
        public bool CanPlay { get { return PhotonNetwork.LocalPlayer.GetNowVoltage() >= Cost; } }

        public delegate void Effect();
        public delegate bool Check();

        public Effect Effects;
        public Check CanActivateEffect;

        public void Init(int id)
        {
            var data = Resources.Load("Data/" + id.ToString()) as CardData;
            Id = data.Id;
            Name = data.Name;
            EffectText = data.EffectText;
            EffectTiming = data.EffectTiming;
            Cost = data.Cost;
            Limited = data.Limited;
            Symbol = data.Symbol;
            AttackPower = data.AttackPower;
            CanResponce = data.CanResponce;
            Responceable = data.Responceable;
            var face = Resources.Load("Textures/" + id.ToString(), typeof(Sprite)) as Sprite;
            Face = (face == null) ? Resources.Load("Textures/CardFace", typeof(Sprite)) as Sprite : face;
            var effectUtil = GetComponent<EffectUtil>();
            var tmp = effectUtil.GetType().GetMethod("Card" + Id);
            if(tmp != null)
            {
                Effects = (Effect)Delegate.CreateDelegate(typeof(Effect), effectUtil, tmp);
            }
        }

        public void PayCost()
        {
            var voltage = PhotonNetwork.LocalPlayer.GetNowVoltage();
            PhotonNetwork.LocalPlayer.SetNowVoltage(voltage - Cost);
        }
    }
}