using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

namespace BladeRondo.UI
{
    public class PlayerNode : MonoBehaviourPunCallbacks 
    {
        [SerializeField]
        private Text _name;
        
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
                    _name.text = PhotonNetwork.LocalPlayer.NickName;
                }
                else
                {
                    _name.text = "プレイヤー待ち";
                }
            }    
            else
            {
                if(this.gameObject.name == "Player")
                {
                    _name.text = PhotonNetwork.LocalPlayer.NickName;
                }
                else
                {
                    _name.text = PhotonNetwork.PlayerListOthers[0].NickName;
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