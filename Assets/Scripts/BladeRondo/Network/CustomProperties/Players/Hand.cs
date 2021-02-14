using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

namespace BladeRondo.Network.CustomProperties.Players
{
    public static class Hand
    {
        public static readonly string _handPros = "Hand";

        public static void SetHand(this Player player, IEnumerable<int> Hand) 
        {
            if(player == null || player.CustomProperties == null)
            {
                return;
            }

            var hashtable = new Hashtable();
            hashtable[_handPros] = Hand.ToArray();
            player.SetCustomProperties(hashtable);
        }

        public static List<int> GetHand(this Player player)
        {
            if(player == null || player.CustomProperties == null || !player.CustomProperties.ContainsKey(_handPros))
            {
                return null;
            }

            var cards = (int[])player.CustomProperties[_handPros];
            return cards.ToList<int>();
        }
    }
}