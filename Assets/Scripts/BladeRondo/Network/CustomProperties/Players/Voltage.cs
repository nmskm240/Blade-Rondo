using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

namespace BladeRondo.Network.CustomProperties.Players
{
    public static class Voltage
    {
        public static readonly string _nowVoltagePros = "NVoltage";

        public static void SetNowVoltage(this Player player, int voltage) 
        {
            if(player == null || player.CustomProperties == null)
            {
                return;
            }

            var hashtable = new Hashtable();
            hashtable[_nowVoltagePros] = voltage;
            player.SetCustomProperties(hashtable);
        }

        public static int GetNowVoltage(this Player player)
        {
            if(player == null || player.CustomProperties == null || !player.CustomProperties.ContainsKey(_nowVoltagePros))
            {
                return -1;
            }

            return (int)player.CustomProperties[_nowVoltagePros];
        }

        public static void AddNowVoltage(this Player player, int num)
        {
            if(player == null || player.CustomProperties == null)
            {
                return ;
            }

            var hashtable = new Hashtable();
            hashtable[_nowVoltagePros] = player.GetNowVoltage() + num;
            player .SetCustomProperties(hashtable);
        }

        public static readonly string _maxVoltagePros = "MVoltage";

        public static void SetMaxVoltage(this Player player, int voltage) 
        {
            if(player == null || player.CustomProperties == null)
            {
                return;
            }

            var hashtable = new Hashtable();
            hashtable[_maxVoltagePros] = voltage;
            player.SetCustomProperties(hashtable);
        }

        public static int GetMaxVoltage(this Player player)
        {
            if(player == null || player.CustomProperties == null || !player.CustomProperties.ContainsKey(_maxVoltagePros))
            {
                return -1;
            }

            return (int)player.CustomProperties[_maxVoltagePros];
        }

        public static void AddMaxVoltage(this Player player, int num)
        {
            if(player == null || player.CustomProperties == null)
            {
                return ;
            }

            var hashtable = new Hashtable();
            hashtable[_maxVoltagePros] = player.GetMaxVoltage() + num;
            player .SetCustomProperties(hashtable);
        }
    }
}