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
        private Counter _hp;
        [SerializeField]
        private Counter _nowVoltage;
        [SerializeField]
        private Counter _maxVoltage;
        [SerializeField]
        private Counter _attack;
        [SerializeField]
        private Counter _defence;

        public override void OnPlayerPropertiesUpdate(Player player, Hashtable hashtable)
        {
            if(hashtable.ContainsKey("HP") || hashtable.ContainsKey("Attack") || hashtable.ContainsKey("Defence") || hashtable.ContainsKey("NVoltage") || hashtable.ContainsKey("MVoltage"))
            {
                var target = (PhotonNetwork.LocalPlayer == player) ? "Player" : "Enemy";
                if(this.transform.parent.gameObject.name == target)
                {
                    if(hashtable.ContainsKey("HP"))
                    {
                        _hp.Count = player.GetHP();
                    }
                    if(hashtable.ContainsKey("Attack"))
                    {
                        _attack.Count = player.GetAttack();
                    }
                    if(hashtable.ContainsKey("NVoltage"))
                    {
                        _nowVoltage.Count = player.GetNowVoltage();
                    }
                    if(hashtable.ContainsKey("MVoltage"))
                    {
                        _maxVoltage.Count = player.GetMaxVoltage();
                    }
                    if(hashtable.ContainsKey("Defence"))
                    {
                        _defence.Count = player.GetDefence();
                    }
                }
            }
        }
    }
}