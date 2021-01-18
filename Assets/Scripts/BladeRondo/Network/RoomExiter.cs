using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

namespace BladeRondo.Network
{    
    public class RoomExiter : MonoBehaviourPunCallbacks 
    {
        private void Awake() 
        {
            GetComponent<Button>().onClick.AddListener(() => { PhotonNetwork.LeaveRoom(); });
        }

        public override void OnLeftRoom()
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}