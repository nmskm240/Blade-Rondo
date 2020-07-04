using UnityEngine;
using Photon.Pun;

public class LobbyManager : MonoBehaviour 
{
    public void OnClickBackButton()
    {
        SceneController.Instance.UnloadScene("LobbyScene");
        PhotonNetwork.LeaveLobby();
    }
}