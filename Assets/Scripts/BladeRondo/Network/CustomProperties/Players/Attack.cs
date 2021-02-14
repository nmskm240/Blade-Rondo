using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

namespace BladeRondo.Network.CustomProperties.Players
{
    public static class Attack
    {
        public static readonly string _attackPros = "Attack";

        public static void SetAttack(this Player player, int attack) 
        {
            if(player == null || player.CustomProperties == null)
            {
                return;
            }

            var hashtable = new Hashtable();
            hashtable[_attackPros] = attack;
            player.SetCustomProperties(hashtable);
        }

        public static int GetAttack(this Player player)
        {
            if(player == null || player.CustomProperties == null || !player.CustomProperties.ContainsKey(_attackPros))
            {
                return -1;
            }

            return (int)player.CustomProperties[_attackPros];
        }

        public static void AddAttack(this Player player, int num)
        {
            if(player == null || player.CustomProperties == null)
            {
                return;
            }

            var hashtable = new Hashtable();
            hashtable[_attackPros] = player.GetAttack() + num;
            player.SetCustomProperties(hashtable);
        }
    }
}