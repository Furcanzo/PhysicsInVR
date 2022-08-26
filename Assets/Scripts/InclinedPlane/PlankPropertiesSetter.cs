using UnityEngine;

namespace InclinedPlane
{
    public class PlankPropertiesSetter : MonoBehaviour
    {
        private Rigidbody _rb;
        public float maxInclination = 60.0f;
    
        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        public void SetInclination(float inclination)
        {
            Vector3 actual = _rb.rotation.eulerAngles;
            actual.z = inclination*maxInclination;
            Quaternion rotation = Quaternion.Euler(actual);

            _rb.rotation = rotation;
        }

    }
}
