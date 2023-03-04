using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Events;
using UnityEngine.UI;

public class Lever : MonoBehaviour
{
    public UnityEvent<float> onMove;
    public float minValue;
    public float maxValue;
    public string variableName;
    
    private float _oldAngle;
    private float _value;
    private HingeJoint _hingeJoint;
    private Canvas _canvas;
    private Text nameText;
    private Text valueText;
    
    // Start is called before the first frame update
    void Start()
    {
        _hingeJoint = GetComponentInChildren<HingeJoint>();
        _canvas = GetComponentInChildren<Canvas>();
        var texts = _canvas.GetComponentsInChildren<Text>();
        nameText = texts.Single(x => x.name == "Name");
        valueText = texts.Single(x => x.name == "Value");
        nameText.text = variableName;
        valueText.text = ((minValue + maxValue) / 2).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(_hingeJoint.angle - _oldAngle) > 0.05f)
        {
            _value = AngleToValue(_hingeJoint.angle);
            onMove.Invoke(_value);
            valueText.text = _value.ToString();
        }

        _oldAngle = _hingeJoint.angle;
    }

    private float AngleToValue(float angle)
    {
        //value between 0 and 1
        float generalValue = ((angle / 60.0f)+1)/2;
        
        float realValue = generalValue * Mathf.Abs(maxValue-minValue) + minValue;
        return realValue;
    }

}
