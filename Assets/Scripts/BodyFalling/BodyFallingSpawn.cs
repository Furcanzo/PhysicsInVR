using UnityEngine;

namespace BodyFalling
{
    public class BodyFallingSpawn : MonoBehaviour
    {
        public float massOfCube = 2;
        public GameObject vectorModel;
        public float cubeVectorScaleFactor = 20.0f;
        public float gravity = Physics.gravity.magnitude;
        public float cubeScaling = 0.8f;
    
        private float _cubeDimension;
        private GameObject _cube;
        private Rigidbody _rb;
        private ShowVectors _vectors;

        public void SpawnStart()
        {
            if (_cube)
            {
                Destroy(_cube);
            }

            _cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _cube.AddComponent<Rigidbody>().mass = massOfCube;
            _rb = _cube.GetComponent<Rigidbody>();
            _cubeDimension = _rb.mass * cubeScaling;
            _cube.transform.localScale = new Vector3(_cubeDimension, _cubeDimension, _cubeDimension);
            _vectors = _cube.AddComponent<ShowVectors>();
            _vectors.vectorModelAddedForce = vectorModel;
            _vectors.showAddedForce = true;
            _vectors.scaleFactor = cubeVectorScaleFactor;
            _rb.useGravity = false;
            _cube.transform.rotation = transform.rotation;
            _cube.transform.position = transform.position;

        }

        private void FixedUpdate()
        {
            if (_cube)
            {
                _vectors.ApplyForce(Vector3.down * (gravity * _rb.mass));
            }
        }

        public void SetMass(float mass)
        {
            massOfCube = (mass + 2);
            _cubeDimension = massOfCube * cubeScaling;
            if (_cube)
            {
                _cube.transform.localScale = new Vector3(_cubeDimension, _cubeDimension, _cubeDimension);
                _rb.mass = massOfCube;
            }
        }

        public void SetGravity(float gravity)
        {
            this.gravity = (gravity + 1)*9.81f;
        }
    
    }
}