using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarMovement : MonoBehaviour

{ 
    private Rigidbody2D carRBD;

    // car speed
    private float carAccelerationInput;

    [SerializeField] private float carSpeedFactor;

    //car turn
    private float steeringInput;

    [SerializeField] private float steeringSpeedFactor;

    private float rotationAngle;

    //car movement
    private Vector2 carMovementVector;

    [SerializeField] private float driftValue;

    [Header ("Drag Settings")]
    [SerializeField] private float reachMaxDragTime;
    [SerializeField] private float dragFactor;

    [Header ("Car Trails Settings")]
    [SerializeField] private float carTrailsSpeedApparition;
    private CarTrailsManager carTrailsManager;
    


    private void Awake()
    {
        carRBD = GetComponent<Rigidbody2D>();

        GetComponent<PlayerCarMovement>().enabled = false;

        carTrailsManager = GetComponentInChildren<CarTrailsManager>();
    }

    private void Update()
    {
        carAccelerationInput = Input.GetAxisRaw("Vertical");

        steeringInput = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        SpeedForceControl();

        OrthogonalVelocityReducer();

        SteeringRotationControl();

    }

    private void SpeedForceControl()
    {
        if (carAccelerationInput == 0)
        {
            carRBD.drag = Mathf.Lerp(0, dragFactor, reachMaxDragTime);

        }
        else 
        { 
            carRBD.drag = 0;

        }

        carMovementVector = carAccelerationInput * transform.up * carSpeedFactor;

        carRBD.AddForce(carMovementVector, ForceMode2D.Force);
    }

    private void OrthogonalVelocityReducer()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(carRBD.velocity, transform.up);

        Vector2 perpendicularVelocity = transform.right * Vector2.Dot(carRBD.velocity, transform.right);

        carRBD.velocity = forwardVelocity + perpendicularVelocity * driftValue;
    }

    private void SteeringRotationControl()
    {
        float minSpeedValueBeforeTurning = carRBD.velocity.magnitude / 8;
        minSpeedValueBeforeTurning = Mathf.Clamp01(minSpeedValueBeforeTurning);

        rotationAngle -= steeringInput * steeringSpeedFactor * minSpeedValueBeforeTurning;

        carRBD.MoveRotation(rotationAngle);

    }

}
