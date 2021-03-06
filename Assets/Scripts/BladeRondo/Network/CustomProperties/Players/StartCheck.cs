using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

namespace BladeRondo.Network.CustomProperties.Players
{
    public static class StartCheck
    {
        public static readonly string _startCheckPros = "SCheck";

        public static void SetStartCheck(this Player player, bool check) 
        {
            if(player == null || player.CustomProperties == null)
            {
                return;
            }

            var hashtable = new Hashtable();
            hashtable[_startCheckPros] = check;
            player.SetCustomProperties(hashtable);
        }

        public static bool GetStartCheck(this Player player)
        {
            if(player == null || player.CustomProperties == null || !player.CustomProperties.ContainsKey(_startCheckPros))
            {
                return false;
            }

            return (bool)player.CustomProperties[_startCheckPros];
        }
    }
}