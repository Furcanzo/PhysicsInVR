using UnityEngine;

namespace ParabolicMotion
{
    public class StandHeightSetter : MonoBehaviour 
    {
        public void SetHeight(float height)
        {
            transform.position = new Vector3( transform.position.x, height, transform.position.z);
        }
    }
}
