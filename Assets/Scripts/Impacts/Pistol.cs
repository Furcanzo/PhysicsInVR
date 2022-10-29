using UnityEngine;

namespace Impacts
{
    public class Pistol : MonoBehaviour
    {
        public float massOfCannonball = 2;
        public GameObject vectorModelAddedForce;
        public GameObject vectorModelCollision;
        public float cannonballVectorScaleFactor = 15.0f;
        public float cannonballScaling = 0.05f;
        public float startForce = 100.0f;
        public bool elastic;
        public GameObject Aim;
        
        private float _cannonballDimension;
        private GameObject _cannonball;
        private Rigidbody _rb;
        private ShowVectors _vectors;

        public void Shoot()
        {
            _cannonball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            PhysicMaterial cannonballMaterial = new PhysicMaterial
            {
                staticFriction = 0.0f,
                dynamicFriction = 0.0f,
                bounciness = elastic? 1.0f : 0.0f,
                bounceCombine = PhysicMaterialCombine.Multiply
            };
            _cannonball.AddComponent<Rigidbody>().mass = massOfCannonball;
            _cannonball.GetComponent<Collider>().material = cannonballMaterial;
            _rb = _cannonball.GetComponent<Rigidbody>();
            _rb.useGravity = false;
            _cannonballDimension = _rb.mass * cannonballScaling;
            _cannonball.transform.localScale = new Vector3(_cannonballDimension, _cannonballDimension, _cannonballDimension);
            _vectors = _cannonball.AddComponent<ShowVectors>();
            _vectors.vectorModelAddedForce = vectorModelAddedForce;
            _vectors.vectorModelCollision = vectorModelCollision;
            _vectors.showAddedForce = true;
            _vectors.showCollision = true;
            _vectors.scaleFactor = cannonballVectorScaleFactor;
            _cannonball.transform.position = Aim.transform.position;
            _vectors.ApplyForce(startForce * (Aim.transform.position - transform.position).normalized);
        }
    }
}
