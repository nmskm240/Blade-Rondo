using UnityEngine;
using UnityEngine.UI;

namespace BladeRondo.UI
{    
    public class Counter : MonoBehaviour 
    {
        [SerializeField]
        private Text _count;

        public int Count { get { return int.Parse(_count.text); } set { _count.text = value.ToString(); } }
    }
}