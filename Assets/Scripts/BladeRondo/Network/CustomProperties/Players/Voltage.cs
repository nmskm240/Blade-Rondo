using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

namespace BladeRondo.Network.CustomProperties.Players
{
    public static class Voltage
    {
        public static readonly string NowVoltagePros = "NVoltage";

        public static void SetNowVoltage(this Player player, int voltage) 
        {
            if(player == null || player.CustomProperties == null)
            {
                return;
            }

            var hashtable = new Hashtable();
            hashtable[NowVoltagePros] = voltage;
            player.SetCustomProperties(hashtable);
        }

        public static int GetNowVoltage(this Player player)
        {
            if(player == null || player.CustomProperties == null || !player.CustomProperties.ContainsKey(NowVoltagePros))
            {
                return -1;
            }

            return (int)player.CustomProperties[NowVoltagePros];
        }

        public static void AddNowVoltage(this Player player, int num)
        {
            if(player == null || player.CustomProperties == null)
            {
                return ;
            }

            var hashtable = new Hashtable();
            hashtable[NowVoltagePros] = player.GetNowVoltage() + num;
            player .SetCustomProperties(hashtable);
        }

        public static readonly string MaxVoltagePros = "MVoltage";

        public static void SetMaxVoltage(this Player player, int voltage) 
        {
            if(player == null || player.CustomProperties == null)
            {
                return;
            }

            var hashtable = new Hashtable();
            hashtable[MaxVoltagePros] = voltage;
            player.SetCustomProperties(hashtable);
        }

        public static int GetMaxVoltage(this Player player)
        {
            if(player == null || player.CustomProperties == null || !player.CustomProperties.ContainsKey(MaxVoltagePros))
            {
                return -1;
            }

            return (int)player.CustomProperties[MaxVoltagePros];
        }

        public static void AddMaxVoltage(this Player player, int num)
        {
            if(player == null || player.CustomProperties == null)
            {
                return ;
            }

            var hashtable = new Hashtable();
            hashtable[MaxVoltagePros] = player.GetMaxVoltage() + num;
            player .SetCustomProperties(hashtable);
        }
    }
}