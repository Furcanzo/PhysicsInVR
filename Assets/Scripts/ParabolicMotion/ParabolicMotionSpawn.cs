using UnityEngine;

namespace ParabolicMotion
{
    public class ParabolicMotionSpawn : MonoBehaviour
    {
        public float massOfCannonball = 2;
        public GameObject vectorModelAddedForce;
        public GameObject vectorModelGravity;
        public float cannonballVectorScaleFactor = 2.0f;
        public float cannonballScaling = 0.8f;
        public float startForce = 2500.0f;
        public GameObject Aim;
        
        private float _cannonballDimension;
        private GameObject _cannonball;
        private Rigidbody _rb;
        private ShowVectors _vectors;

        public void LoadCannon()
        {
        }

        public void Fire()
        {
            if (_cannonball)
            {
                Destroy(_cannonball);
            }

            _cannonball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            _cannonball.AddComponent<Rigidbody>().mass = massOfCannonball;
            _rb = _cannonball.GetComponent<Rigidbody>();
            _cannonballDimension = _rb.mass * cannonballScaling;
            _cannonball.transform.localScale = new Vector3(_cannonballDimension, _cannonballDimension, _cannonballDimension);
            _vectors = _cannonball.AddComponent<ShowVectors>();
            _vectors.vectorModelAddedForce = vectorModelAddedForce;
            _vectors.vectorModelGravity = vectorModelGravity;
            _vectors.showAddedForce = true;
            _vectors.showGravity = true;
            _vectors.scaleFactor = cannonballVectorScaleFactor;
            _cannonball.AddComponent<TrailRenderer>();
            _cannonball.transform.position = transform.position;
            _vectors.ApplyForce(startForce * (Aim.transform.position - transform.position).normalized);
        }

        public void SetMass(float mass)
        {
            massOfCannonball = mass;
            _cannonballDimension = massOfCannonball * cannonballScaling;
            if (_cannonball)
            {
                _cannonball.transform.localScale = new Vector3(_cannonballDimension, _cannonballDimension, _cannonballDimension);
                _rb.mass = massOfCannonball;
            }
        }

        public void SetForce(float force)
        {
            this.startForce = force;
        }

    }
}