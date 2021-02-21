using UnityEngine;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using BladeRondo.Game.Component;
using BladeRondo.Network.CustomProperties.Rooms;
using BladeRondo.System;

namespace BladeRondo.Network.RaiseEvents
{
    public class PlayCard : RaiseEventPractitioner
    {
        public override void OnEvent(EventData photonEvent)
        {
            if(photonEvent.Code == (byte)RaiseEventType.PlayCard)
            {
                var subject = GetComponent<MonoBehaviourSubject<Card>>();
                var targetViewID = (int)photonEvent.CustomData;
                Card targetCard = null;
                foreach(Transform tf in this.transform)
                {
                    if(tf.gameObject.GetComponent<PhotonView>().ViewID == targetViewID)
                    {
                        targetCard = tf.gameObject.GetComponent<Card>();
                        break;
                    }
                }
                subject.NotifyObservers(targetCard);
            }
        }
    }
}