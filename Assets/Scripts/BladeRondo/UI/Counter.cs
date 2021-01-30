using UnityEngine;
using UnityEngine.UI;

namespace BladeRondo.UI
{    
    public class Counter : MonoBehaviour 
    {
        [SerializeField]
        private Text count;

        public int Count { get { return int.Parse(count.text); } set { count.text = value.ToString(); } }
    }
}