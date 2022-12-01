using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    [SerializeField] Transform playerTransform;

    [SerializeField] Transform playerCarTransform;

    private bool incar;

    private void Awake()
    {
        incar = false;
    }

    private void Update()
    {

        if(incar == false)
        {
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(playerCarTransform.position.x, playerCarTransform.position.y, transform.position.z);
        }
       
    }

    public bool InCar(bool _incar)
    {
        incar = _incar;
        return incar;
    }
}
