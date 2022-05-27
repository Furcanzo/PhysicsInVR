using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;

public class HandPresencePhysics : MonoBehaviour
{

    public InputDeviceCharacteristics controllerCharacteristics;
    
    public GameObject handModelPrefab;

    private GameObject _spawnedHandModel;

    private InputDevice _targetDevice;
    private Animator _handAnimator;
    private static readonly int Trigger = Animator.StringToHash("Trigger");
    private static readonly int Grip = Animator.StringToHash("Grip");
    public Transform target;
    private Rigidbody _rb;
    private Collider[] _handColliders;
    
    // Start is called before the first frame update
    void Start()
    {
        TryInitialize();
        _spawnedHandModel = Instantiate(handModelPrefab, transform);
        _spawnedHandModel.SetLayerRecursively(gameObject.layer);
        _handAnimator = _spawnedHandModel.GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _handColliders = GetComponentsInChildren<Collider>();
    }

    public void EnableColliders()
    {
        foreach (Collider item in _handColliders)
        {
            item.enabled = true;
        }
    }
    
    public void EnableCollidersDelay(float delay)
    {
        Invoke(nameof(EnableColliders), delay);
    }
    
    public void DisableColliders()
    {
        foreach (Collider item in _handColliders)
        {
            item.enabled = false;
        }
    }
    
    void TryInitialize()
    {
        var inputDevices = new List<InputDevice>(); 
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, inputDevices);

        if (inputDevices.Count == 0)
        {
            return;
        }

        _targetDevice = inputDevices[0];
    }

    void UpdateHandAnimation()
    {
        if(_targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            _handAnimator.SetFloat(Trigger, triggerValue);
        }
        else
        {
            _handAnimator.SetFloat(Trigger, 0);
        }
        
        if(_targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            _handAnimator.SetFloat(Grip, gripValue);
        }
        else
        {
            _handAnimator.SetFloat(Grip, 0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.velocity = (target.position - transform.position) / Time.fixedDeltaTime;
        Quaternion rotationDifference = target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDifference.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);
        Vector3 rotationDifferenceInDegree = angleInDegree * rotationAxis;
        _rb.angularVelocity = (rotationDifferenceInDegree * Mathf.Deg2Rad / Time.fixedDeltaTime);

    }
    
    // Update is called once per frame
    void Update()
    {
        if (!_targetDevice.isValid)
        {
            TryInitialize();
        }
        else
        {
            UpdateHandAnimation();
        }
       
    }
}
