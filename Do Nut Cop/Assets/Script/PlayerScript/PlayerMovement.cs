using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerMovementSpeed;

    [SerializeField] private Transform playerInteractionPosition;

    private Vector2 playerMovementVector;

    private Rigidbody2D rbd;

    private BoxCollider2D boxCollider;

    private SpriteRenderer sr;

    private Animator anor;

    private bool playerFacingSide;
    private bool playerFacingUp;
    private bool playerFacingDown;

    private void Awake()
    {
        rbd = GetComponent<Rigidbody2D>();

        boxCollider = GetComponent<BoxCollider2D>();

        sr = GetComponent<SpriteRenderer>();

        anor = GetComponent<Animator>();
    }

    private void Update()
    {
        //playerMovement
        playerMovementVector.x = Input.GetAxisRaw("Horizontal");

        playerMovementVector.y = Input.GetAxisRaw("Vertical");

        DiagonalMovementRestriction();

        //playerFlip, interaction position and animation; Horizontal
        HorizontalSpriteSet();

        //playerFlip, interaction position and animation; Vertical
        VerticalSpriteSet();

        //stopping animation when no movement; Going Idle
        IdleDirectionSet();
    }

    private void FixedUpdate()
    {
        rbd.MovePosition (rbd.position + playerMovementVector * playerMovementSpeed * Time.fixedDeltaTime);
    }

    private void DiagonalMovementRestriction()
    {
        if (playerMovementVector.y != 0f)
        {
            playerMovementVector.x = 0f;
        }
    }

    private void HorizontalSpriteSet() // also hase interaction position
    {
        if (playerMovementVector.x < -0.1f)
        {

            sr.flipX = true;
            playerInteractionPosition.position = new Vector3(transform.position.x - 1, transform.position.y, playerInteractionPosition.position.z);

            anor.ResetTrigger("CopUpWalkTrigger");
            anor.ResetTrigger("CopDownWalkTrigger");
            anor.SetTrigger("CopSideWalkTrigger");

            //condition for idle
            playerFacingSide = true;
            playerFacingDown = false;
            playerFacingUp = false;
        }
        else
        {
            if (playerMovementVector.x > 0.1f)
            {

                sr.flipX = false;
                playerInteractionPosition.position = new Vector3(transform.position.x + 1, transform.position.y, playerInteractionPosition.position.z);

                anor.ResetTrigger("CopUpWalkTrigger");
                anor.ResetTrigger("CopDownWalkTrigger");
                anor.SetTrigger("CopSideWalkTrigger");

                //condition for idle
                playerFacingSide = true;
                playerFacingDown = false;
                playerFacingUp = false;
            }
        }
    }

    private void VerticalSpriteSet()
    {
        if (playerMovementVector.y > 0)
        {
            playerInteractionPosition.position = new Vector3(transform.position.x, transform.position.y + 1, playerInteractionPosition.position.z);

            anor.ResetTrigger("CopDownWalkTrigger");
            anor.ResetTrigger("CopSideWalkTrigger");
            anor.SetTrigger("CopUpWalkTrigger");

            playerFacingUp = true;
            playerFacingDown = false;
            playerFacingSide = false;
        }
        else
        {
            if (playerMovementVector.y < 0)
            {

                playerInteractionPosition.position = new Vector3(transform.position.x, transform.position.y - 1, playerInteractionPosition.position.z);

                anor.ResetTrigger("CopUpWalkTrigger");
                anor.ResetTrigger("CopSideWalkTrigger");
                anor.SetTrigger("CopDownWalkTrigger");


                //condition for idle
                playerFacingDown = true;
                playerFacingUp = false;
                playerFacingSide = false;
            }
        }
    }
    private void IdleDirectionSet()
    {
        //stopping animation when no movement; Going Idle
        if (playerMovementVector.x == 0 && playerFacingSide == true)
        {
            anor.ResetTrigger("CopSideWalkTrigger");
            anor.SetTrigger("CopSideIdleTrigger");
        }

        if (playerMovementVector.y == 0 && playerFacingUp == true)
        {
            anor.ResetTrigger("CopUpWalkTrigger");
            anor.SetTrigger("CopUpIdleTrigger");
        }
        else
        {
            if (playerMovementVector.y == 0 && playerFacingDown == true)
            {
                anor.ResetTrigger("CopDownWalkTrigger");
                anor.SetTrigger("CopDownIdleTrigger");
            }
        }
    }
}
