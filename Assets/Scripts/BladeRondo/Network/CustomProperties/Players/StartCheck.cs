using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

namespace BladeRondo.Network.CustomProperties.Players
{
    public static class StartCheck
    {
        public static readonly string StartCheckPros = "SCheck";

        public static void SetStartCheck(this Player player, bool check) 
        {
            if(player == null || player.CustomProperties == null)
            {
                return;
            }

            var hashtable = new Hashtable();
            hashtable[StartCheckPros] = check;
            player.SetCustomProperties(hashtable);
        }

        public static bool GetStartCheck(this Player player)
        {
            if(player == null || player.CustomProperties == null || !player.CustomProperties.ContainsKey(StartCheckPros))
            {
                return false;
            }

            return (bool)player.CustomProperties[StartCheckPros];
        }
    }
}