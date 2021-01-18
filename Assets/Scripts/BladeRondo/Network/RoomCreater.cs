using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

namespace BladeRondo.Network
{    
    public class RoomCreater : MonoBehaviour 
    {
        private RoomOptions Options = new RoomOptions()
        {
            MaxPlayers = 2,
        };

        private void Awake() 
        {
            GetComponent<Button>().onClick.AddListener(() => { PhotonNetwork.CreateRoom(Random.Range(100, 1000).ToString(), Options); });    
        }
    }
}