using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SetMovementSystem : MonoBehaviour
{
    public GameObject RayInteractor;
    
    // Start is called before the first frame update
    void Start()
    {
        int ContinuousMovement = PlayerPrefs.GetInt("ContinuousMovement");
        int ContinuousTurn = PlayerPrefs.GetInt("ContinuousTurn");
        if (ContinuousMovement == 1)
        {
            GetComponent<TeleportationProvider>().enabled = false;
            GetComponent<ContinuousMoveProviderBase>().enabled = true;
            RayInteractor.SetActive(false);
            PlayerPrefs.SetInt("ContinuousMovement", 0);
        }
        if (ContinuousTurn == 1)
        {
            GetComponent<SnapTurnProviderBase>().enabled = false;
            GetComponent<ContinuousTurnProviderBase>().enabled = true;
            PlayerPrefs.SetInt("ContinuousTurn", 0);
        }
    }
    
}
