using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.E))
        {
            boxCollider.enabled = true;
        }
        else
        { 
            boxCollider.enabled = false; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerCar")
        collision.GetComponent<PlayerCarInteraction>().PlayerInteractionComingIn();
        
        if(collision.tag == "DonutStore")
        collision.GetComponent<DonutStoreInteraction>().DonutNumberOnCopIncrease();

        if(collision.tag == "PoliceStation")
        {
            collision.GetComponent<PoliceStationInteraction>().DonutNumberInPSIncrease();
        }
    }

}
