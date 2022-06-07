using UnityEngine;

public class InclinationSetter : MonoBehaviour
{

    public void SetInclination(float inclination)
    {
        Vector3 actual = transform.rotation.eulerAngles;
        actual.z = inclination*180.0f+180.0f;
        Quaternion rotation = Quaternion.Euler(actual);

        transform.rotation = rotation;
    }
}
