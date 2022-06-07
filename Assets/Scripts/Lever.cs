using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Lever : MonoBehaviour
{

    public float value;
    
    public UnityEvent<float> onMove;
    
    private Quaternion _oldRotation;
    // Start is called before the first frame update
    void Start()
    {
        _oldRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation != _oldRotation)
        {
            value = transform.rotation.eulerAngles.x/60.0f;
            onMove.Invoke(value);
            
        }

        _oldRotation = transform.rotation;
    }
    
    
    
}
