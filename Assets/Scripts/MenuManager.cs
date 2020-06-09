using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class MenuManager : MonoBehaviourPunCallbacks 
{
    [SerializeField]
    private GameObject BackButton;
    [SerializeField]
    private GameObject BattleButton;
    [SerializeField]
    private GameObject DeckEditButton;
    [SerializeField]
    private GameObject RoomDialog;

    public void OnClickBattleButton()
    {
        GameObject obj = BattleButton.transform.parent.gameObject;
        obj.SetActive(false);
        RoomDialog.SetActive(true);
        BackButton.SetActive(true);
        PhotonNetwork.JoinLobby();   
    }

    public void OnClickDeckEditButton()
    {
        //Load deck edit scene
        BackButton.SetActive(true);
    }

    public void OnClickBackButton()
    {
        GameObject obj = BattleButton.transform.parent.gameObject;
        obj.SetActive(true);
        RoomDialog.SetActive(false);
        BackButton.SetActive(false);
        PhotonNetwork.LeaveLobby();
    }

    public override void OnJoinedRoom()
    {
        SceneManager.LoadScene("GameScene");
    }
}