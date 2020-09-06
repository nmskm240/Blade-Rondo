namespace BladeRondo.Player
{
    using UnityEngine;
    public class AttackManager : MonoBehaviour
    {
        private static int MAX_ATTACK = 9;
        private int NowAttack = 0;

        public void AddAttack(int attack)
        {
            NowAttack += attack;
        }

        public int GetAttack()
        {
            return NowAttack;
        }
    }
}