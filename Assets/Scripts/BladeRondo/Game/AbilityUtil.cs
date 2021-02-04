using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using BladeRondo.Network.CustomProperties.Players;

namespace BladeRondo.Game
{
    public class AbilityUtil
    {
        public void Card1()
        {
            PhotonNetwork.LocalPlayer.AddAttack(1);
        }
    }
}