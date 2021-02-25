using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

namespace BladeRondo.Network.CustomProperties.Players
{
    public static class PickCards
    {
        public static readonly string _pickCardsPros = "PickCards";

        public static void SetPickCards(this Player player, IEnumerable<int> pickCards) 
        {
            if(player == null || player.CustomProperties == null)
            {
                return;
            }

            var hashtable = new Hashtable();
            hashtable[_pickCardsPros] = pickCards.ToArray();
            player.SetCustomProperties(hashtable);
        }

        public static List<int> GetPickCards(this Player player)
        {
            if(player == null || player.CustomProperties == null || !player.CustomProperties.ContainsKey(_pickCardsPros))
            {
                return null;
            }

            var cards = (int[])player.CustomProperties[_pickCardsPros];
            return cards.ToList<int>();
        }
    }
}