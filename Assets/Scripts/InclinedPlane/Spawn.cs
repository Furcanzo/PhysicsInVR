using System.Net.NetworkInformation;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float massOfCube = 1;
    public GameObject vectorModel;
    public float cubeStatFriction = 0.5f;
    public float cubeDynFriction = 0.5f;
    public float cubeScaleFactor = 20.0f;

    private GameObject _cube;
    private Rigidbody _rb;

    public void SpawnStart()
    {
        if (_cube)
        {
            Destroy(_cube);
        }
        _cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        _cube.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
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
        vectors.vectorModel = vectorModel;
        vectors.showFriction = true;
        vectors.showNormal = true;
        vectors.scaleFactor = cubeScaleFactor;
        _cube.transform.rotation = transform.rotation;
        _cube.transform.position = transform.position;
        
    }

    public void SetStaticFriction(float staticFriction)
    {
            cubeStatFriction = (staticFriction+1)/2;
        if (_cube)
        {
            _cube.GetComponent<Collider>().material.staticFriction = cubeStatFriction;
            _rb.WakeUp();
        }
    }
    
    public void SetDynamicFriction(float dynamicFriction)
    {
            cubeDynFriction = (dynamicFriction+1)/2;
        if (_cube)
        {
            _cube.GetComponent<Collider>().material.dynamicFriction = cubeDynFriction;
            _rb.WakeUp();
        }

    }
}
