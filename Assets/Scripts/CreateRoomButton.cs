using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon.Pun;

public class CreateRoomButton : MonoBehaviourPunCallbacks
{
    private RoomOptions roomOptions = new RoomOptions()
    {
        MaxPlayers = 2,
        IsVisible = true,
        IsOpen = true
    };

    public void OnClick()
    {
        PhotonNetwork.CreateRoom("", roomOptions);
    }
}
