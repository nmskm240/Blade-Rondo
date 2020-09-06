using System.Collections;
using System.Collections.Generic;

namespace BladeRondo.System
{
    public class Deck
    {
        private List<string> deck = new List<string>();

        public string Draw()
        {
            string str = deck[0];
            deck.RemoveAt(0);
            return str;
        }
    }
}