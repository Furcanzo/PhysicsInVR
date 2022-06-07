using UnityEngine;

public class ShowVectors : MonoBehaviour
{
    private Rigidbody _rb;
    private PhysicMaterial _material;

    public GameObject vectorModel;

    public float scaleFactor = 3.0f;
    public float proportion = 2.0f;
    
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
        _gravityVector = Instantiate(vectorModel);
        _collisionVector = Instantiate(vectorModel);
        _frictionVector = Instantiate(vectorModel);
        _addedForceVector = Instantiate(vectorModel);
    }

    // Update is called once per frame
    void Update()
    {
        _gravityForce = _rb.mass * Physics.gravity;
        float gravityScale = scaleFactor * _gravityForce.magnitude;
        _gravityVector.transform.localScale = new Vector3(gravityScale/proportion, gravityScale/proportion,gravityScale);
        var position = transform.position;
        _gravityVector.transform.position = position;
        _gravityVector.transform.rotation = Quaternion.LookRotation(_gravityForce.normalized, Vector3.up);
        
        float collisionScale = scaleFactor * _collisionForce.magnitude;
        _collisionVector.transform.localScale = new Vector3(collisionScale/proportion,collisionScale/proportion,collisionScale);
        _collisionVector.transform.position = position;
        _collisionVector.transform.rotation = Quaternion.LookRotation(_collisionForce.normalized, Vector3.up);
        
        float frictionScale = scaleFactor * _frictionForce.magnitude;
        _frictionVector.transform.localScale = new Vector3(frictionScale/proportion,frictionScale/proportion,frictionScale);
        _frictionVector.transform.position = position;
        _frictionVector.transform.rotation = Quaternion.LookRotation(_frictionForce.normalized, Vector3.up);
        
        float addedScale = scaleFactor * _addedForce.magnitude;
        _addedForceVector.transform.localScale = new Vector3(addedScale/proportion,addedScale/proportion,addedScale);
        _addedForceVector.transform.position = position;
        _addedForceVector.transform.rotation = Quaternion.LookRotation(_addedForce.normalized, Vector3.up);

    }

    private void OnCollisionEnter(Collision other)
    {
        _collisionForce = other.impulse/Time.deltaTime;
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
