namespace BladeRondo.System
{
    using Photon.Pun;
    using Photon.Realtime;
    using Hashtable = ExitGames.Client.Photon.Hashtable;

    /// <summary>
    /// Photon.Realtime.Playerの拡張メソッドを作成するクラス
    /// </summary>
    public static class PlayerProperty
    {
        private const string HpKey = "hp";
        private const string VoltageKey = "V";
        private const string AttackKey = "A";
        private const string DefenceKey = "D";

        private static Hashtable hashtable = new Hashtable()
        {
            [VoltageKey] = 0,
            [AttackKey] = 0,
            [DefenceKey] = 0
        };

        /// <summary>
        /// プレイヤーのHPゲッター
        /// </summary>
        public static int GetHp(this Player player)
        {
            return (int)player.CustomProperties[HpKey];
        }

        /// <summary>
        /// プレイヤーのVoltageゲッター
        /// </summary>
        public static int GetVoltage(this Player player)
        {
            return (int)player.CustomProperties[VoltageKey];
        }

        /// <summary>
        /// プレイヤーのAttackゲッター
        /// </summary>
        public static int GetAttack(this Player player)
        {
            return (int)player.CustomProperties[AttackKey];
        }

        /// <summary>
        /// プレイヤーのDefenceゲッター
        /// </summary>
        public static int GetDefence(this Player player)
        {
            return (int)player.CustomProperties[DefenceKey];
        }
    }
}