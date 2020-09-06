namespace BladeRondo.Player
{
    using UnityEngine;
    public class DefenceManager : MonoBehaviour
    {
        private static int MAX_DEFENCE = 9;
        private int NowDefence = 0;

        public void AddDefence(int defence)
        {
            NowDefence += defence;
        }

        public int GetDefence()
        {
            return NowDefence;
        }
    }
}