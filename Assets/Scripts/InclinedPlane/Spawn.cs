using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float massOfCube = 1;
    public GameObject vectorModel;
    public float cubeStatFriction = 0.3f;
    public float cubeDynFriction = 0.3f;

    private GameObject _cube;
    
    public void SpawnStart()
    {
        if (_cube)
        {
            Destroy(_cube);
        }
        _cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        _cube.AddComponent<Rigidbody>().mass = massOfCube;
        PhysicMaterial cubeMaterial = new PhysicMaterial
        {
            staticFriction = cubeStatFriction,
            dynamicFriction = cubeDynFriction
        };
        _cube.GetComponent<Collider>().material = cubeMaterial;
        ShowVectors vectors = _cube.AddComponent<ShowVectors>();
        vectors.vectorModel = vectorModel;
        vectors.showFriction = true;
        vectors.showNormal = true;
        vectors.scaleFactor = 20;
        _cube.transform.rotation = transform.rotation;
        _cube.transform.position = transform.position;
        
    }
}
