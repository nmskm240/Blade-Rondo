namespace BladeRondo.Player
{
    using UnityEngine;
    public class HPManager : MonoBehaviour
    {
        private static int MAX_HP = 15;
        private int NowHP = 0;

        public void AddHP(int hp)
        {
            NowHP += (NowHP >= MAX_HP) ? 0 : hp;
        }

        public int GetHP()
        {
            return NowHP;
        }
    }
}