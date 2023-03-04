using UnityEngine;

namespace ParabolicMotion
{
    public class CannonInclinationSetter : MonoBehaviour
    {

        public void SetInclination(float inclination)
        {
            Vector3 actual = transform.localRotation.eulerAngles;
            actual.y = inclination;
            Quaternion rotation = Quaternion.Euler(actual);
            transform.localRotation = rotation;
        }

    }
}
