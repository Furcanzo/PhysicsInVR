using UnityEngine;

namespace InclinedPlane
{
    public class InclinedPlaneSpawn : MonoBehaviour
    {
        public float massOfCube = 2;
        public GameObject vectorModelFriction;
        public GameObject vectorModelGravity;
        public GameObject vectorModelNormal;
        public float cubeStatFriction = 0.5f;
        public float cubeDynFriction = 0.5f;
        public float cubeVectorScaleFactor = 20.0f;
        public float cubeDimension = 0.5f;

        private float _cubeScaling = 0.2f;
        private GameObject _cube;
        private Rigidbody _rb;

        public void SpawnStart()
        {
            if (_cube)
            {
                Destroy(_cube);
            }
            _cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _cube.transform.localScale = new Vector3(cubeDimension, cubeDimension, cubeDimension);
            _cube.AddComponent<Rigidbody>().mass = massOfCube;
        
            PhysicMaterial cubeMaterial = new PhysicMaterial
            {
                staticFriction = cubeStatFriction,
                dynamicFriction = cubeDynFriction,
                frictionCombine = PhysicMaterialCombine.Multiply
            };
        
            _cube.GetComponent<Collider>().material = cubeMaterial;
            _rb = _cube.GetComponent<Rigidbody>();
            ShowVectors vectors = _cube.AddComponent<ShowVectors>();
            vectors.vectorModelFriction = vectorModelFriction;
            vectors.vectorModelNormal = vectorModelGravity;
            vectors.vectorModelGravity = vectorModelNormal;
            vectors.showFriction = true;
            vectors.showNormal = true;
            vectors.showGravity = true;
            vectors.scaleFactor = cubeVectorScaleFactor;
            _cube.transform.rotation = transform.rotation;
            _cube.transform.position = transform.position;
        
        }
    
        public void SetMass(float mass)
        { 
            massOfCube = mass;
            cubeDimension = massOfCube * _cubeScaling;
            if (_cube)
            {
                _cube.transform.localScale = new Vector3(cubeDimension, cubeDimension, cubeDimension);
                _rb.mass = massOfCube;
                _rb.WakeUp();
            }
        }

        public void SetStaticFriction(float staticFriction)
        { 
            cubeStatFriction = staticFriction;
            if (_cube)
            {
                _cube.GetComponent<Collider>().material.staticFriction = cubeStatFriction;
                _rb.WakeUp();
            }
        }
    
        public void SetDynamicFriction(float dynamicFriction)
        {
            cubeDynFriction = dynamicFriction;
            if (_cube)
            {
                _cube.GetComponent<Collider>().material.dynamicFriction = cubeDynFriction;
                _rb.WakeUp();
            }

        }
    }
}
