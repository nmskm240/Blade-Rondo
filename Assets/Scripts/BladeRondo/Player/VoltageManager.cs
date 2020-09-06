namespace BladeRondo.Player
{
    using UnityEngine;
    public class VoltageManager
    {
        private static int MAX_VOLTAGE = 9;
        public int NowVoltage = 0;
        public int UnusedVoltage = 0;

        public void AddVoltage(int voltage)
        {
            NowVoltage += voltage;
            UnusedVoltage = NowVoltage;
        }
    }
}