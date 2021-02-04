using Photon.Pun;
using Photon.Realtime;
using BladeRondo.Network.CustomProperties.Players;
using BladeRondo.System;

namespace BladeRondo.System.TurnState.Steps
{
    public class VoltageRefflesh : IState
    {
        public void Execute()
        {
            PhotonNetwork.LocalPlayer.SetNowVoltage(PhotonNetwork.LocalPlayer.GetMaxVoltage() + 1);
            PhotonNetwork.LocalPlayer.AddMaxVoltage(1);
        }
    }
}