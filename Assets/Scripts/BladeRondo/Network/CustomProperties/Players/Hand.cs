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
        public static readonly string HandPros = "Hand";

        public static void SetHand(this Player player, IEnumerable<int> Hand) 
        {
            if(player == null || player.CustomProperties == null)
            {
                return;
            }

            var hashtable = new Hashtable();
            hashtable[HandPros] = Hand.ToArray();
            player.SetCustomProperties(hashtable);
        }

        public static List<int> GetHand(this Player player)
        {
            if(player == null || player.CustomProperties == null || !player.CustomProperties.ContainsKey(HandPros))
            {
                return null;
            }

            var cards = (int[])player.CustomProperties[HandPros];
            return cards.ToList<int>();
        }
    }
}