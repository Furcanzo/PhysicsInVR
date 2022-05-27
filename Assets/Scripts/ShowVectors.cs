using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowVectors : MonoBehaviour
{
    private Rigidbody rb = null;

    private Vector3 velocity = Vector3.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
