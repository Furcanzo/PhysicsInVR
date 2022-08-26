using UnityEngine;

namespace ParabolicMotion
{
    public class StandHeightSetter : MonoBehaviour 
    {
        public void SetHeight(float height)
        {
            float realHeight = (height + 1) * 2.5f;
            transform.position = new Vector3( transform.position.x,realHeight, transform.position.z);
        }
    }
}
