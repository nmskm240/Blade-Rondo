using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using BladeRondo.Game.Component.CardState;
using BladeRondo.Network.CustomProperties.Players;
using BladeRondo.System;

namespace BladeRondo.Game.Component
{    
    public class Card : MonoBehaviour 
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string AbilityText { get; private set; }
        public int Cost { get; private set; }
        public bool Limited { get; private set; }
        public CardType Symbol { get; private set; }
        public int AttackPower { get; private set; }
        public List<CardType> Responceable { get; private set; }
        public Sprite Face { get; private set; }
        public bool InHand { get { return this.transform.parent.gameObject.name == "Hand"; } }

        public delegate void Ability();
        public delegate bool Check();

        public Ability Abilities;
        public Check CanActivateAbility;

        public void Init(int id)
        {
            var data = Resources.Load("Data/" + id.ToString()) as CardData;
            Id = data.Id;
            Name = data.Name;
            AbilityText = data.AbilityText;
            Cost = data.Cost;
            Limited = data.Limited;
            Symbol = data.Symbol;
            AttackPower = data.AttackPower;
            Responceable = data.Responceable;
            var face = Resources.Load("Textures/" + id.ToString(), typeof(Sprite)) as Sprite;
            Face = (face == null) ? Resources.Load("Textures/CardFace", typeof(Sprite)) as Sprite : face;
        }

        public bool CanPlay()
        {
            return PhotonNetwork.LocalPlayer.GetNowVoltage() >= Cost;
        }

        [PunRPC]
        public void Play()
        {
            var player = this.transform.parent.parent.gameObject;
            var playArea = player.transform.Find("PlayArea").gameObject;
            this.transform.SetParent(playArea.transform);
        } 

        public void PayCost()
        {
            var voltage = PhotonNetwork.LocalPlayer.GetNowVoltage();
            PhotonNetwork.LocalPlayer.SetNowVoltage(voltage - Cost);
        }
    }
}