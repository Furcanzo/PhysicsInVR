using UnityEngine;

namespace Impacts
{
    public class TargetSpawn : MonoBehaviour
    {
        public float massOfTarget = 3;
        public GameObject vectorModelCollision;
        public float targetVectorScaleFactor = 20.0f;
    
        private float _targetDimension;
        private GameObject _target;
        private Rigidbody _rb;
        private ShowVectors _vectors;

        public void SpawnStart()
        {
            if (_target)
            {
                Destroy(_target);
            }

            _target = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _target.AddComponent<Rigidbody>().mass = massOfTarget;
            _rb = _target.GetComponent<Rigidbody>();
            PhysicMaterial targetMaterial = new PhysicMaterial
            {
                staticFriction = 0.0f,
                dynamicFriction = 0.0f,
                bounciness = 1.0f,
                bounceCombine = PhysicMaterialCombine.Multiply
            };
            _target.GetComponent<Collider>().material = targetMaterial;
            _targetDimension = 0.5f;
            _target.transform.localScale = new Vector3(_targetDimension, _targetDimension, _targetDimension);
            _vectors = _target.AddComponent<ShowVectors>();
            _vectors.vectorModelCollision = vectorModelCollision;
            _vectors.showCollision = true;
            _vectors.scaleFactor = targetVectorScaleFactor;
            _rb.useGravity = false;
            _target.transform.rotation = transform.rotation;
            _target.transform.position = transform.position;

        }
        
        public void SetMass(float mass)
        {
            massOfTarget = mass;
            if (_target)
            {
                _rb.mass = massOfTarget;
            }
        }
    }
}