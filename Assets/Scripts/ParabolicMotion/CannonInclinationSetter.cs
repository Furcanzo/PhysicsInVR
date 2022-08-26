using UnityEngine;

namespace ParabolicMotion
{
    public class CannonInclinationSetter : MonoBehaviour
    {
        public float maxInclination = 90.0f;

        public void SetInclination(float inclination)
        {
            Vector3 actual = transform.localRotation.eulerAngles;
            actual.y = (inclination+1)*maxInclination/2.0f;
            Quaternion rotation = Quaternion.Euler(actual);
            transform.localRotation = rotation;
        }

    }
}
