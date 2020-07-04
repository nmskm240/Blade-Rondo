using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomList : MonoBehaviourPunCallbacks 
{
    [SerializeField]
    private GameObject Content;
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("room list update" + roomList.Count);
        DestoryAllRoomNode();
        foreach(RoomInfo room in roomList)
        {
            GameObject roomNodeObj = Instantiate(Resources.Load<GameObject>("Prefabs/Room Prefab"));
            roomNodeObj.transform.SetParent(Content.transform);
            roomNodeObj.GetComponent<RoomNode>().SetRoomName(room.Name);
        }
    }

    public void DestoryAllRoomNode()
    {
        foreach(Transform tf in Content.transform)
        {
            tf.gameObject.SetActive(false);
            Destroy(tf.gameObject);
        }
    }
}