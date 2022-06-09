using System;
using UnityEngine;

public class PlankPropertiesSetter : MonoBehaviour
{
    private Collider _material;
    private Rigidbody _rb;
    public float maxInclination = 60.0f;
    
    private void Start()
    {
        _material = GetComponent<Collider>();
        _rb = GetComponent<Rigidbody>();
    }

    public void SetInclination(float inclination)
    {
        Vector3 actual = _rb.rotation.eulerAngles;
        actual.z = inclination*maxInclination;
        Quaternion rotation = Quaternion.Euler(actual);

        _rb.rotation = rotation;
    }

    public void SetStaticFriction(float staticFriction)
    {
        _material.material.staticFriction = Math.Abs((staticFriction+1)/2);
        //todo force friction update
    }
    
    public void SetDynamicFriction(float dynamicFriction)
    {
        _material.material.dynamicFriction = Math.Abs((dynamicFriction+1)/2);
        //todo force friction update
        
    }
}
