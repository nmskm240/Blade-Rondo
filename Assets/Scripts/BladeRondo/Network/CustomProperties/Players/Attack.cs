using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

namespace BladeRondo.Network.CustomProperties.Players
{
    public static class Attack
    {
        public static readonly string AttackPros = "Attack";

        public static void SetAttack(this Player player, int attack) 
        {
            if(player == null || player.CustomProperties == null)
            {
                return;
            }

            var hashtable = new Hashtable();
            hashtable[AttackPros] = attack;
            player.SetCustomProperties(hashtable);
        }

        public static int GetAttack(this Player player)
        {
            if(player == null || player.CustomProperties == null || !player.CustomProperties.ContainsKey(AttackPros))
            {
                return -1;
            }

            return (int)player.CustomProperties[AttackPros];
        }
    }
}