using System;
using UnityEngine;

public class ShowVectors : MonoBehaviour
{
    
    public GameObject vectorModel;

    public float scaleFactor = 3.0f;
    public float proportion = 2.0f;

    public bool showCollision = true;
    public bool showGravity= true;
    public bool showFriction = true;
    public bool showAddedForce = true;
    
    private Rigidbody _rb;
    private PhysicMaterial _material;
    
    private Vector3 _collisionForce;
    private GameObject _collisionVector;
    private Vector3 _gravityForce;
    private GameObject _gravityVector;
    private Vector3 _frictionForce;
    private GameObject _frictionVector;
    private Vector3 _addedForce;
    private GameObject _addedForceVector;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        _material = gameObject.GetComponent<PhysicMaterial>();
        if (showCollision)
        {
            _collisionVector = Instantiate(vectorModel);
        }
        if (showGravity)
        {
            _gravityVector = Instantiate(vectorModel);
        }
        if (showFriction)
        {
            _frictionVector = Instantiate(vectorModel);
        }
        if (showAddedForce)
        {
            _addedForceVector = Instantiate(vectorModel);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var position = transform.position;
        _gravityForce = _rb.mass * Physics.gravity;
        if (showCollision)
        {
            float collisionScale = 10.0f * scaleFactor * (float)Math.Log(_collisionForce.magnitude!=0 ? _collisionForce.magnitude : 1);
            _collisionVector.transform.localScale = new Vector3(collisionScale/proportion,collisionScale/proportion,collisionScale);
            _collisionVector.transform.position = position;
            _collisionVector.transform.rotation = Quaternion.LookRotation(_collisionForce, Vector3.up);
        }

        if (showGravity)
        {
            float gravityScale = 10.0f * scaleFactor * (float)Math.Log(_gravityForce.magnitude!=0 ? _gravityForce.magnitude : 1);
            _gravityVector.transform.localScale = new Vector3(gravityScale / proportion, gravityScale / proportion, gravityScale);
            _gravityVector.transform.position = position;
            _gravityVector.transform.rotation = Quaternion.LookRotation(_gravityForce, Vector3.up);
        }

        if (showFriction)
        {
            float frictionScale = 10.0f * scaleFactor * (float)Math.Log(_frictionForce.magnitude!=0 ? _frictionForce.magnitude : 1);
            _frictionVector.transform.localScale = new Vector3(frictionScale/proportion,frictionScale/proportion,frictionScale);
            _frictionVector.transform.position = position;
            _frictionVector.transform.rotation = Quaternion.LookRotation(_frictionForce, Vector3.up);
        }

        if (showAddedForce)
        {
            float addedScale = 10.0f * scaleFactor * (float)Math.Log(_addedForce.magnitude!=0 ? _addedForce.magnitude : 1);
            _addedForceVector.transform.localScale = new Vector3(addedScale/proportion,addedScale/proportion,addedScale);
            _addedForceVector.transform.position = position;
            _addedForceVector.transform.rotation = Quaternion.LookRotation(_addedForce, Vector3.up);
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.impulse != Vector3.zero)
        {
            _collisionForce = other.impulse / Time.deltaTime;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        
        //TODO friction
    }

    public void ApplyForce(Vector3 force)
    {
        _addedForce = force;
        _rb.AddForce(force);
    }
}
