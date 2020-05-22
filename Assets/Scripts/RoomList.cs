using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomList : MonoBehaviourPunCallbacks 
{
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        DestoryAllRoomNode();
        foreach(RoomInfo room in roomList)
        {
            GameObject roomNodeObj = Instantiate(Resources.Load<GameObject>("Prefabs/Room Prefab"));
            roomNodeObj.transform.SetParent(this.transform.GetChild(0).GetChild(0));
            roomNodeObj.GetComponent<RoomNode>().SetRoomName(room.Name);
        }
    }

    public void DestoryAllRoomNode()
    {
        foreach(Transform tf in this.transform)
        {
            tf.gameObject.SetActive(false);
            Destroy(tf.gameObject);
        }
    }
}