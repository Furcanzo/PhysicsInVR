using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleManager : MonoBehaviour
{
    public void ContinuousMovement(bool active)
    {
        PlayerPrefs.SetInt("ContinuousMovement", active? 1 : 0);
    }
    
    public void ContinuousTurn(bool active)
    {
        PlayerPrefs.SetInt("ContinuousTurn", active? 1 : 0);
    }
}
