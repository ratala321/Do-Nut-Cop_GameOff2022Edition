using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTrailsManager : MonoBehaviour
{
    /*private PlayerCarMovement playerCarMovement;

    private bool trailRendererEmissionActive;

    [SerializeField] private GameObject[] carTrails;

    private void Awake()
    {
        playerCarMovement = GetComponentInParent<PlayerCarMovement>();

        for (int i = 0; i < carTrails.Length; i++)
        {
            carTrails[i].GetComponent<TrailRenderer>().emitting = false;
        }
    }

    private void Update()
    {
        if (trailRendererEmissionActive == true)
        {
            for (int i = 0; i < carTrails.Length; i++)
            {
                carTrails[i].GetComponent<TrailRenderer>().emitting = true;
            }
        }
        else
        {
            for (int i = 0; i < carTrails.Length; i++)
            {
                carTrails[i].GetComponent<TrailRenderer>().emitting = false;
            }
        }
    }

    public bool ActivateTrailsEmission(bool _activationBool)
    {
        trailRendererEmissionActive = _activationBool;

        return trailRendererEmissionActive;
    }*/
}
