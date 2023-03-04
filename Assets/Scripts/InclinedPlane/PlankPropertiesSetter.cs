using UnityEngine;

namespace InclinedPlane
{
    public class PlankPropertiesSetter : MonoBehaviour
    {
        private Rigidbody _rb;
    
        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        public void SetInclination(float inclination)
        {
            Vector3 actual = _rb.rotation.eulerAngles;
            actual.z = inclination;
            Quaternion rotation = Quaternion.Euler(actual);

            _rb.rotation = rotation;
        }

    }
}
