using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

public class TurnManager : MonoBehaviourPunCallbacks, IPunTurnManagerCallbacks
{
    [SerializeField]
    private PunTurnManager punTurnManager;

    public void OnTurnBegins(int turn)
    {

    }

    public void OnTurnCompleted(int turn)
    {

    }

    public void OnPlayerMove(Player player, int turn, object o)
    {

    }

    public void OnPlayerFinished(Player player, int turn, object o)
    {

    }

    public void OnTurnTimeEnds(int turn)
    {

    }
}