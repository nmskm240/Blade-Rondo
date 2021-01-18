using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

namespace BladeRondo.UI
{
    public class PlayerNode : MonoBehaviourPunCallbacks 
    {
        [SerializeField]
        private Text Name;
        [SerializeField]
        private Image Icon;
        
        private void Awake() 
        {
            Init();    
        }

        private void Init() 
        {
            if(PhotonNetwork.PlayerList.Length != 2)
            {
                if(this.gameObject.name == "Player")
                {
                    Name.text = PhotonNetwork.LocalPlayer.NickName;
                }
                else
                {
                    Name.text = "プレイヤー待ち";
                }
            }    
            else
            {
                if(this.gameObject.name == "Player")
                {
                    Name.text = PhotonNetwork.LocalPlayer.NickName;
                }
                else
                {
                    Name.text = PhotonNetwork.PlayerListOthers[0].NickName;
                }
            }
        }

        public override void OnPlayerEnteredRoom(Player player)
        {
            Init();
        }

        public override void OnPlayerLeftRoom(Player player)
        {
            Init();
        }
    }
}