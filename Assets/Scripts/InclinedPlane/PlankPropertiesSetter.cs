using UnityEngine;

public class PlankPropertiesSetter : MonoBehaviour
{
    private Collider _material;

    private void Start()
    {
        _material = GetComponent<Collider>();
    }

    public void SetInclination(float inclination)
    {
        Vector3 actual = transform.rotation.eulerAngles;
        actual.z = inclination*180.0f+180.0f;
        Quaternion rotation = Quaternion.Euler(actual);

        transform.rotation = rotation;
    }

    public void SetStaticFriction(float staticFriction)
    {
        _material.material.staticFriction = (staticFriction+1)/2;
    }
    
    public void SetDynamicFriction(float dynamicFriction)
    {
        _material.material.dynamicFriction = (dynamicFriction+1)/2;
    }
}
