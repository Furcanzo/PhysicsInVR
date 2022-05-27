using UnityEngine;

public class InclinationSetter : MonoBehaviour
{
    public float delta = 10.0f;

    public void IncrementInclination()
    {
        Vector3 actual = transform.rotation.eulerAngles;
        actual.z += delta;
        Quaternion rotation = Quaternion.Euler(actual);

        transform.rotation = rotation;
    }
    
    public void ReduceInclination()
    {
        Vector3 actual = transform.rotation.eulerAngles;
        actual.z -= 10.0f;
        Quaternion rotation = Quaternion.Euler(actual);

        transform.rotation = rotation;
    }
}
