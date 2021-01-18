using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

namespace BladeRondo.Network
{    
    public class RoomConnecter : MonoBehaviourPunCallbacks, IConnecter
    {
        public void Connect()
        {
            SceneManager.LoadScene("RoomScene");
        }

        public override void OnJoinedRoom()
        {
            Connect();
        }
    }
}