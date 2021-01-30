using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using BladeRondo.Network.CustomProperties.Players;

namespace BladeRondo.UI
{    
    public class PlayerParameters : MonoBehaviourPunCallbacks 
    {
        [SerializeField]
        private Counter Hp;
        [SerializeField]
        private Counter NowVoltage;
        [SerializeField]
        private Counter MaxVoltage;
        [SerializeField]
        private Counter Attack;
        [SerializeField]
        private Counter Defence;

        public override void OnPlayerPropertiesUpdate(Player player, Hashtable hashtable)
        {
            if(hashtable.ContainsKey("HP") || hashtable.ContainsKey("Attack") || hashtable.ContainsKey("Defence") || hashtable.ContainsKey("NVoltage") || hashtable.ContainsKey("MVoltage"))
            {
                var target = (PhotonNetwork.LocalPlayer == player) ? "Player" : "Enemy";
                if(this.transform.parent.gameObject.name == target)
                {
                    if(hashtable.ContainsKey("HP"))
                    {
                        Hp.Count = player.GetHP();
                    }
                    if(hashtable.ContainsKey("Attack"))
                    {
                        Attack.Count = player.GetAttack();
                    }
                    if(hashtable.ContainsKey("NVoltage"))
                    {
                        NowVoltage.Count = player.GetNowVoltage();
                    }
                    if(hashtable.ContainsKey("MVoltage"))
                    {
                        MaxVoltage.Count = player.GetMaxVoltage();
                    }
                    if(hashtable.ContainsKey("Defence"))
                    {
                        Defence.Count = player.GetDefence();
                    }
                }
            }
        }
    }
}