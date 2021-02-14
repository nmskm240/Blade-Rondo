using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

namespace BladeRondo.Network.CustomProperties.Rooms
{
    public static class TurnPlayer
    {
        public static readonly string _turnPlayerPros = "TurnPlayer";

        public static void SetTurnPlayer(this Room room, Player turnPlayer) 
        {
            if(room == null || room.CustomProperties == null)
            {
                return;
            }

            var hashtable = new Hashtable();
            hashtable[_turnPlayerPros] = turnPlayer;
            room.SetCustomProperties(hashtable);
        }

        public static Player GetTurnPlayer(this Room room)
        {
            if(room == null || room.CustomProperties == null || !room.CustomProperties.ContainsKey(_turnPlayerPros))
            {
                return null;
            }

            return (Player)room.CustomProperties[_turnPlayerPros];
        }
    }
}