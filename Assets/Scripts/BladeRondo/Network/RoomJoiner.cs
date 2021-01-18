using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

namespace BladeRondo.Network
{    
    public class RoomJoiner : MonoBehaviour 
    {
        private void Awake() 
        {
            GetComponent<Button>().onClick.AddListener(() => { PhotonNetwork.JoinRandomRoom(); });
        }
    }
}