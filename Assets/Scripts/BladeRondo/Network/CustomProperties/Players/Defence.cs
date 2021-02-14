using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

namespace BladeRondo.Network.CustomProperties.Players
{
    public static class Defence
    {
        public static readonly string _defencePros = "Defence";

        public static void SetDefence(this Player player, int defence) 
        {
            if(player == null || player.CustomProperties == null)
            {
                return;
            }

            var hashtable = new Hashtable();
            hashtable[_defencePros] = defence;
            player.SetCustomProperties(hashtable);
        }

        public static int GetDefence(this Player player)
        {
            if(player == null || player.CustomProperties == null || !player.CustomProperties.ContainsKey(_defencePros))
            {
                return -1;
            }

            return (int)player.CustomProperties[_defencePros];
        }
    }
}