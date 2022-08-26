using UnityEngine;

namespace Impacts
{
    public class Pistol : MonoBehaviour
    {
        public float massOfCannonball = 2;
        public GameObject vectorModel;
        public float cannonballVectorScaleFactor = 2.0f;
        public float cannonballScaling = 0.05f;
        public float startForce = 100.0f;
        public GameObject Aim;
        
        private float _cannonballDimension;
        private GameObject _cannonball;
        private Rigidbody _rb;
        private ShowVectors _vectors;

        public void Shoot()
        {
            _cannonball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            _cannonball.AddComponent<Rigidbody>().mass = massOfCannonball;
            _rb = _cannonball.GetComponent<Rigidbody>();
            _rb.useGravity = false;
            _cannonballDimension = _rb.mass * cannonballScaling;
            _cannonball.transform.localScale = new Vector3(_cannonballDimension, _cannonballDimension, _cannonballDimension);
            _vectors = _cannonball.AddComponent<ShowVectors>();
            _vectors.vectorModel = vectorModel;
            _vectors.showAddedForce = true;
            _vectors.showCollision = true;
            _vectors.scaleFactor = cannonballVectorScaleFactor;
            _cannonball.transform.position = Aim.transform.position;
            _vectors.ApplyForce(startForce * (Aim.transform.position - transform.position).normalized);
        }
    }
}
