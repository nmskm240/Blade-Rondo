using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using BladeRondo.Network;
using BladeRondo.Network.CustomProperties.Players;

namespace BladeRondo.UI
{    
    public class GameStartChecker : MonoBehaviourPunCallbacks 
    {
        private void Awake() 
        {
            GetComponent<Button>().onClick.AddListener(() => 
            {
                this.transform.GetChild(0).gameObject.GetComponent<Text>().text = (PhotonNetwork.LocalPlayer.GetStartcheck()) ? "準備完了" : "キャンセル";
                PhotonNetwork.LocalPlayer.SetStartCheck((PhotonNetwork.LocalPlayer.GetStartcheck()) ? false : true); 
            });    
        }

        private bool IsBothPlayersReady()
        {
            bool isReady = true;
            if(PhotonNetwork.PlayerList.Length != 2)
            {
                return false;
            }
            foreach(var player in PhotonNetwork.PlayerList)
            {
                isReady = isReady && player.GetStartcheck();
            }
            return isReady;
        }

        public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
        {
            if(IsBothPlayersReady())
            {
                new GameConnecter().Connect();
            }
        }
    }
}