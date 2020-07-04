using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

public class TurnManager : MonoBehaviourPunCallbacks, IPunTurnManagerCallbacks
{
    [SerializeField]
    private PunTurnManager punTurnManager;

    public void Start()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            // punTurnManager.BeginTurn();
        }
    }

    public void OnTurnBegins(int turn)
    {

    }

    public void OnTurnCompleted(int turn)
    {
        if(PhotonNetwork.IsMasterClient)
        {
            punTurnManager.BeginTurn();
        }
    }

    public void OnPlayerMove(Player player, int turn, object o)
    {

    }

    public void OnPlayerFinished(Player player, int turn, object o)
    {
        bool turnEndIsMine = (player == PhotonNetwork.LocalPlayer)? true : false;
        Transform field = GameObject.Find(turnEndIsMine? "Player" : "Enemy").transform.Find("Field");
        foreach(Transform cardTF in field)
        {
            cardTF.gameObject.GetComponent<BladeRondo.Card.CardController>().ReturnHand();
        }
    }

    public void OnTurnTimeEnds(int turn)
    {

    }

    public void OnClickTurnEnd()
    {
        punTurnManager.SendMove(0, true);
    }
}