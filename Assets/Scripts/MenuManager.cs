using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class MenuManager : MonoBehaviourPunCallbacks 
{
    [SerializeField]
    private GameObject BackButton;
    [SerializeField]
    private GameObject BattleButton;
    [SerializeField]
    private GameObject DeckEditButton;

    public void Awake()
    {
        PhotonNetwork.LocalPlayer.NickName = "Guest" + Random.Range(1000, 9999);
    }

    public void OnClickBattleButton()
    {
        SceneController.Instance.LoadScene("LobbyScene");
        PhotonNetwork.JoinLobby();   
    }

    public void OnClickDeckEditButton()
    {
        //Load deck edit scene
        BackButton.SetActive(true);
    }
}