using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

namespace BladeRondo.Network.CustomProperties.Players
{
    public static class HP
    {
        public static readonly string _hpPros = "HP";

        public static void SetHP(this Player player, int hp) 
        {
            if(player == null || player.CustomProperties == null)
            {
                return;
            }

            var hashtable = new Hashtable();
            hashtable[_hpPros] = hp;
            player.SetCustomProperties(hashtable);
        }

        public static int GetHP(this Player player)
        {
            if(player == null || player.CustomProperties == null || !player.CustomProperties.ContainsKey(_hpPros))
            {
                return -1;
            }

            return (int)player.CustomProperties[_hpPros];
        }

        public static void AddHP(this Player player, int num)
        {
            if(player == null || player.CustomProperties == null)
            {
                return;
            }

            var hashtable = new Hashtable();
            var nowHp = player.GetHP();
            nowHp += num;
            nowHp = (nowHp > 15) ? 15 : nowHp;
            nowHp = (nowHp < 0) ? 0 : nowHp;
            hashtable[_hpPros] = nowHp;
            player.SetCustomProperties(hashtable);
        }
    }
}