using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

namespace BladeRondo.UI
{    
    public class RoomIdViewer : MonoBehaviour 
    {
        [SerializeField]
        private Text RoomId;

        private void Awake()
        {
            RoomId.text = PhotonNetwork.CurrentRoom.Name;
        }
    }
}