using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using BladeRondo.Game;
using BladeRondo.Game.Component;
using BladeRondo.Network.CustomProperties.Players;
using BladeRondo.System;

namespace BladeRondo.Game.Effect
{
    public class PlayPickCards : IEffect
    {
        public bool CanActivate()
        {
            return true;
        }

        public void Activate()
        {
            var factory = new NetworkCardFactory();
            var pickCardIDs = PhotonNetwork.LocalPlayer.GetPickCards();
            var player = GameObject.Find("Players").transform.Find("Player").gameObject;
            var playArea = player.transform.Find("PlayArea").gameObject.GetComponent<PlayArea>();
            foreach(var id in pickCardIDs)
            {
                var card = factory.Create(id);
                playArea.Put(card);
            }
        }
    }
}