using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using BladeRondo.Game.Component;
using BladeRondo.Network.CustomProperties.Players;

namespace BladeRondo.Game
{
    public class EffectUtil : MonoBehaviour
    {
        public void Card0()
        {
            PhotonNetwork.LocalPlayer.AddAttack(1);
        }

        public void Card1()
        {
            var cost = GetComponent<Card>().Cost;
            PhotonNetwork.LocalPlayer.SetDefence(cost);
        }

        public void Card2()
        {
            PhotonNetwork.LocalPlayer.AddNowVoltage(1);
        }

        public void Card10()
        {
            PhotonNetwork.LocalPlayer.AddHP(-3);
        }

        public void Card15()
        {
            PhotonNetwork.LocalPlayer.AddHP(4);
        }
    }
}