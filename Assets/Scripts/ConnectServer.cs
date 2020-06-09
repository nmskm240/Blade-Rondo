using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class ConnectServer : MonoBehaviourPunCallbacks
{
    private int count= 0;

    public void Update()
    {
        if(Input.GetMouseButton(0) && count == 0)
        {
            count++;
            Debug.Log("クリック");
            Connect();
        }
    }

    private void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("server in");
    }

    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("MenuScene");   
    }
}