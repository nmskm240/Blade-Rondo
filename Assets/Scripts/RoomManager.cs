using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text PlayerNickNameText;
    [SerializeField]
    private Text EnemyNickNameText;

    public void OnClickBattleStart()
    {
        SceneController.Instance.LoadScene("GameScene");
    }

    public void OnClickXButton()
    {
        SceneController.Instance.LoadScene("LobbyScene");
        PhotonNetwork.LeaveRoom();
    }

    public override void OnJoinedRoom()
    {
        PlayerNickNameText.text = PhotonNetwork.LocalPlayer.NickName;
        EnemyNickNameText.text = (PhotonNetwork.IsMasterClient)? "No Player" : PhotonNetwork.MasterClient.NickName;
    }

    public override void OnLeftRoom()
    {

    }

    public override void OnPlayerEnteredRoom(Player NewPlayer)
    {
        EnemyNickNameText.text = NewPlayer.NickName;
    }

    public override void OnPlayerLeftRoom(Player LeavePlayer)
    {
        EnemyNickNameText.text = "No Player";
    }
}