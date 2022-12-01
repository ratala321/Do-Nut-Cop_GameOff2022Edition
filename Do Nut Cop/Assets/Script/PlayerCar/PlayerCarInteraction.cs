using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarInteraction : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject camObject;

    private bool playerInsideCar;

    private void Update()
    {
        if (playerInsideCar)
        {
            if (Input.GetKey(KeyCode.Q))
                PlayerInteractionComingOut();
        }
    }

    public void PlayerInteractionComingIn()
    {
        player.GetComponent<SpriteRenderer>().enabled = false;

        player.GetComponent<PlayerMovement>().enabled = false;

        player.transform.position = transform.position;

        GetComponent<PlayerCarMovement>().enabled = true;

        playerInsideCar = true;

        camObject.GetComponent<CameraSettings>().InCar(true);
    }

    private void PlayerInteractionComingOut()
    {
        player.GetComponent<SpriteRenderer>().enabled = true;

        player.GetComponent<PlayerMovement>().enabled = true;

        player.transform.position = new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z);

        GetComponent<PlayerCarMovement>().enabled = false;
        
        playerInsideCar = false;
        
        camObject.GetComponent<CameraSettings>().InCar(false);
    }
}
