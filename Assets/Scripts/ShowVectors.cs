using System;
using UnityEngine;

public class ShowVectors : MonoBehaviour
{
    
    public GameObject vectorModel;

    public float scaleFactor = 5.0f;
    public float proportion = 2.0f;

    public bool showCollision;
    public bool showGravity;
    public bool showFriction;
    public bool showNormal;
    public bool showAddedForce;
    
    private Rigidbody _rb;
    private PhysicMaterial _material;
    
    private Vector3 _collisionForce;
    private GameObject _collisionVector;
    private Vector3 _gravityForce;
    private GameObject _gravityVector;
    private Vector3 _frictionForce;
    private GameObject _frictionVector;
    private Vector3 _normalForce;
    private GameObject _normalVector;
    private Vector3 _addedForce;
    private GameObject _addedForceVector;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        _material = gameObject.GetComponent<Collider>().material;
        if (showCollision)
        {
            _collisionVector = Instantiate(vectorModel, gameObject.transform, true);
        }
        if (showGravity)
        {
            _gravityVector = Instantiate(vectorModel, gameObject.transform, true);
        }
        if (showFriction)
        {
            _frictionVector = Instantiate(vectorModel, gameObject.transform, true);
        }
        if (showNormal)
        {
            _normalVector = Instantiate(vectorModel, gameObject.transform, true);
        }
        if (showAddedForce)
        {
            _addedForceVector = Instantiate(vectorModel, gameObject.transform, true);
        }
    }
    
    void FixedUpdate()
    {
        var position = transform.position;
        _gravityForce = _rb.mass * Physics.gravity;
        if (showCollision)
        {
            if (_collisionForce != Vector3.zero)
            {
                _collisionVector.SetActive(true);
                float collisionScale = 10.0f * scaleFactor * (float)Math.Log(_collisionForce.magnitude!=0 ? _collisionForce.magnitude : 1);
                _collisionVector.transform.localScale = new Vector3(collisionScale/proportion,collisionScale/proportion,collisionScale);
                _collisionVector.transform.position = position;
                _collisionVector.transform.rotation = Quaternion.LookRotation(_collisionForce, Vector3.up);
            }
            else
            {
                _collisionVector.SetActive(false);
            }
        }

        if (showGravity)
        {
            if (_gravityForce != Vector3.zero)
            {
                _gravityVector.SetActive(true);
                float gravityScale = 10.0f * scaleFactor * (float)Math.Log(_gravityForce.magnitude!=0 ? _gravityForce.magnitude : 1);
                _gravityVector.transform.localScale = new Vector3(gravityScale / proportion, gravityScale / proportion, gravityScale);
                _gravityVector.transform.position = position;
                _gravityVector.transform.rotation = Quaternion.LookRotation(_gravityForce, Vector3.up);
            }
            else
            {
                _gravityVector.SetActive(false);
            }
        }

        if (showFriction)
        {
            if (_frictionForce != Vector3.zero)
            {
                _frictionVector.SetActive(true);
                float frictionScale = 10.0f * scaleFactor * (float)Math.Log(_frictionForce.magnitude!=0 ? _frictionForce.magnitude : 1);
                _frictionVector.transform.localScale = new Vector3(frictionScale/proportion,frictionScale/proportion,frictionScale);
                _frictionVector.transform.position = position;
                _frictionVector.transform.rotation = Quaternion.LookRotation(_frictionForce, Vector3.up);
            }
            else
            {
                _frictionVector.SetActive(false);
            }
        }
        
        if (showNormal)
        {
            if (_normalForce != Vector3.zero)
            {
                _normalVector.SetActive(true);
                float normalScale = 10.0f * scaleFactor * (float)Math.Log(_normalForce.magnitude!=0 ? _normalForce.magnitude : 1);
                _normalVector.transform.localScale = new Vector3(normalScale/proportion,normalScale/proportion,normalScale);
                _normalVector.transform.position = position;
                _normalVector.transform.rotation = Quaternion.LookRotation(_normalForce, Vector3.up);
            }
            else
            {
                _normalVector.SetActive(false);
            }
        }

        if (showAddedForce)
        {
            if (_addedForce != Vector3.zero)
            {
                _addedForceVector.SetActive(true);
                float addedScale = 10.0f * scaleFactor * (float)Math.Log(_addedForce.magnitude!=0 ? _addedForce.magnitude : 1);
                _addedForceVector.transform.localScale = new Vector3(addedScale/proportion,addedScale/proportion,addedScale);
                _addedForceVector.transform.position = position;
                _addedForceVector.transform.rotation = Quaternion.LookRotation(_addedForce, Vector3.up);
            }
            else
            {
                _addedForceVector.SetActive(false);
            }
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.impulse != Vector3.zero)
        {
            _collisionForce = other.impulse / Time.deltaTime;
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        //todo check
        float frictionParam = _rb.velocity != Vector3.zero //Check if the object is moving
            ? other.collider.sharedMaterial.dynamicFriction //If it use the dynamic friction parameter
            : other.collider.sharedMaterial.staticFriction; //Otherwise use the static friction
        
        _normalForce = Quaternion.Euler(0, 0,transform.rotation.eulerAngles.z) * (-_gravityForce * (float)Math.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad));
        _frictionForce =  Quaternion.Euler(0, 0,90) * (_normalForce*frictionParam) * (transform.rotation.eulerAngles.z>300? 1 : -1);
    }

    public void ApplyForce(Vector3 force)
    {
        _addedForce = force;
        _rb.AddForce(force);
    }
}