using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRRayInteractor))]

public class RayToggler : MonoBehaviour
{

    [SerializeField] private InputActionReference activateReference = null;
    
    private XRRayInteractor _rayInteractor = null;
    private bool _isEnabled = false;

    private void Awake()
    {
        _rayInteractor = GetComponent<XRRayInteractor>();
    }

    private void OnEnable()
    {
        activateReference.action.started += ToggleRay;
        activateReference.action.canceled += ToggleRay;
    }

    private void OnDisable()
    {
        activateReference.action.started -= ToggleRay;
        activateReference.action.canceled -= ToggleRay;
    }

    private void ToggleRay(InputAction.CallbackContext context)
    {
        _isEnabled = context.control.IsPressed();
    }

    private void LateUpdate()
    {
        ApplyStatus();
    }


    private void ApplyStatus()
    {
        if (_rayInteractor.enabled != _isEnabled)
        {
            _rayInteractor.enabled = _isEnabled;
        }
    }
}