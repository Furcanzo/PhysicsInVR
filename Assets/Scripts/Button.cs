using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public GameObject button;

    public UnityEvent onPress;
    public UnityEvent onRelease;

    private GameObject _presser;

    private AudioSource _sound;

    private MeshRenderer _meshRenderer;

    private bool _isPressed;
    // Start is called before the first frame update
    void Start()
    {
        _sound = GetComponent<AudioSource>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isPressed)
        {
            
            _presser = other.gameObject;
            onPress.Invoke();
            _sound.Play();
            _isPressed = true;
            _meshRenderer.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _presser)
        {
            onRelease.Invoke();
            _isPressed = false;
            _meshRenderer.enabled = true;
        }
    }

    public void test()
    {
        Debug.Log("______________________________________!!!!!!!!!!!!");
    }
}
