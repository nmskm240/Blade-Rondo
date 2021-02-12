using UnityEngine;

namespace BladeRondo.Game.Component
{
    public class Cemetery : MonoBehaviour
    {
        private void OnTransformChildrenChanged() 
        {
            foreach(Transform tf in this.transform)
            {
                tf.localPosition = new Vector3(0,0,0);
            }
        }
    }
}