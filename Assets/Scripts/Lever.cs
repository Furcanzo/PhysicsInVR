using System;
using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    public UnityEvent<float> onMove;
    
    private float _oldAngle;
    private float _value;
    private HingeJoint _hingeJoint;
    
    // Start is called before the first frame update
    void Start()
    {
        _hingeJoint = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(_hingeJoint.angle - _oldAngle) > 0.05f)
        {
            _value = AngleToValue(_hingeJoint.angle);
            onMove.Invoke(_value);
        }

        _oldAngle = _hingeJoint.angle;
    }

    private float AngleToValue(float angle)
    {
        return angle / 60.0f;
    }

}
