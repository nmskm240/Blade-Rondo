using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using BladeRondo.Game.Component;
using BladeRondo.Network.CustomProperties.Rooms;
using BladeRondo.System;
using BladeRondo.System.TurnState.Steps;

namespace BladeRondo.System.TurnState.Phases
{
    public class End : IState
    {
        private List<IState> Steps = new List<IState>()
        {
            new EnemyReturn(),
            new PlayerReturn(),
        };

        public void Execute()
        {
            foreach (var step in Steps)
            {
                step.Execute();
            }
            var nextPlayer = PhotonNetwork.CurrentRoom.GetTurnPlayer().GetNext();
            PhotonNetwork.CurrentRoom.SetTurnPlayer(nextPlayer);
        }
    }
}