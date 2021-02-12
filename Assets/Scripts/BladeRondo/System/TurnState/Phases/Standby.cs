using System.Collections;
using System.Collections.Generic;
using BladeRondo.Network.CustomProperties.Players;
using BladeRondo.System;
using BladeRondo.System.TurnState.Steps;

namespace BladeRondo.System.TurnState.Phases
{
    public class Standby : IState
    {
        private IState NowStep;
        private List<IState> Steps = new List<IState>()
        {
            new VoltageRefflesh(),
            new ActivateAttachedEffect(),
            new ActivateDeploymentsEffect(),
        };

        public void Execute()
        {
            foreach(var step in Steps)
            {
                step.Execute();
            }
        }
    }
}