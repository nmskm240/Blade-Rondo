using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

namespace BladeRondo.Network.CustomProperties.Rooms
{
    public static class Deck
    {
        public static readonly string _deckPros = "Deck";

        public static void SetDeck(this Room room, IEnumerable<int> Deck) 
        {
            if(room == null || room.CustomProperties == null)
            {
                return;
            }

            var hashtable = new Hashtable();
            hashtable[_deckPros] = Deck.ToArray();
            room.SetCustomProperties(hashtable);
        }

        public static List<int> GetDeck(this Room room)
        {
            if(room == null || room.CustomProperties == null)
            {
                return null;
            }
            else if(!room.CustomProperties.ContainsKey(_deckPros))
            {
                var stdDeck =  new List<int>()
                {
                    3,3,4,4,5,5,6,6,7,7,8,8,9,9,10,10,11,11,12,12,13,13,14,14,15,15,16,16,17,17,18,18,20,20,21,21,22,22,23,23
                };
                return stdDeck.OrderBy ( a => Guid.NewGuid () ).ToList ();
            }

            var cards = (int[])room.CustomProperties[_deckPros];
            return cards.ToList<int>();
        }
    }
}