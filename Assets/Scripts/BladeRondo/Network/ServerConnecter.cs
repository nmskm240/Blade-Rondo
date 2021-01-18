using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Photon.Pun;

namespace BladeRondo.Network
{    
    public class ServerConnecter : MonoBehaviourPunCallbacks, IPointerClickHandler, IConnecter
    {
        public void Connect()
        {
            PhotonNetwork.ConnectUsingSettings();
        }

        public void OnPointerClick(PointerEventData e)
        {
            Connect();
        }

        public override void OnConnectedToMaster()
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}