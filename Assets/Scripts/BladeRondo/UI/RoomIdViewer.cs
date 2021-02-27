using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

namespace BladeRondo.UI
{    
    public class RoomIDViewer : MonoBehaviour 
    {
        [SerializeField]
        private Text _roomID;

        private void Awake()
        {
            _roomID.text = PhotonNetwork.CurrentRoom.Name;
        }
    }
}