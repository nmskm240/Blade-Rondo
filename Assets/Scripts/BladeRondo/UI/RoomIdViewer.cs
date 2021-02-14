using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

namespace BladeRondo.UI
{    
    public class RoomIdViewer : MonoBehaviour 
    {
        [SerializeField]
        private Text _roomId;

        private void Awake()
        {
            _roomId.text = PhotonNetwork.CurrentRoom.Name;
        }
    }
}