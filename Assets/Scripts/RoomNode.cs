using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class RoomNode : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text RoomName;

    public void SetRoomName(string RoomName)
    {
        this.RoomName.text = RoomName;
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(RoomName.text);
    }
}