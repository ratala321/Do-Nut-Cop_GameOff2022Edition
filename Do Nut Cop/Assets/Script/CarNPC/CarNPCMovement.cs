using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarNPCMovement : MonoBehaviour
{
    [SerializeField] private float positionWhereCarDisappear;

    [SerializeField] private float MovementSpeed;

    [SerializeField] private int carMaxLifeTime;
    
    private float timerCounter;

    private Vector3 initalPosition;

    private void OnEnable()
    {
        initalPosition = transform.position;

        timerCounter = 0;
    }

    private void OnDisable()
    {
        transform.position = initalPosition;

        timerCounter = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "PlayerCar" || collision.transform.tag == "Player")
        {
            GetComponentInParent<CarNPCSelection>().CarApparition();

            if (collision.transform.position.x < transform.position.x)
            {
                collision.rigidbody.AddForce(new Vector2(-2, 0), ForceMode2D.Impulse);
            }
            else
            {
                collision.rigidbody.AddForce(new Vector2(2, 0), ForceMode2D.Impulse);
            }
            
            if (collision.transform.position.y < transform.position.y)
            {
                collision.rigidbody.AddForce(new Vector2(0, -2), ForceMode2D.Impulse);
            }
            else
            {
                collision.rigidbody.AddForce(new Vector2(0, 2), ForceMode2D.Impulse);
            }

            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        transform.Translate(0, MovementSpeed*Time.deltaTime, 0);
        if (MovementSpeed > 0)
        {
            if (transform.position.y >= positionWhereCarDisappear)
            {
                GetComponentInParent<CarNPCSelection>().CarApparition();

                gameObject.SetActive(false);
            }
        }
        else
        {
            if (transform.position.y <= positionWhereCarDisappear)
            {
                GetComponentInParent<CarNPCSelection>().CarApparition();

                gameObject.SetActive(false);
            }
        }
        

        timerCounter += Time.deltaTime;

        if (timerCounter > carMaxLifeTime)
        {
            GetComponentInParent<CarNPCSelection>().CarApparition();

            gameObject.SetActive(false);
        }

    }

    //method that make the car disapears when reaching a certain location (condition in Update)

    //movement by translate in Update

    //call to carApparition() in carNPCSelection when the car is disappearing

    //reset inital position when disappearing (use Awake or OnEnable)

    //lifetime in Update just in case


}
