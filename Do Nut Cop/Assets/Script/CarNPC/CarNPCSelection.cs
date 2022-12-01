using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarNPCSelection : MonoBehaviour
{
    [SerializeField] GameObject[] carNPC;
    Transform[] carNPCinitialPosition;

    private int carNumber;

    private int lastCarNumber;

    private void Awake()
    {
        /*for (int i = 0; i < carNPC.Length; i++)
        {
            carNPCinitialPosition[i].position = carNPC[i].transform.position;
        }*/ //May not be necessary --> initialposition in car movement for each car instead?

        CarApparition();
    }
    
    public void CarApparition()
    {
        RandomSelectionOfCar();

        lastCarNumber = carNumber;

        carNPC[carNumber].SetActive(true);
        carNPC[carNumber].GetComponent<CarNPCMovement>().enabled = true;
    }

    private void RandomSelectionOfCar()
    {
        carNumber = Random.Range(0, carNPC.Length);

        if (carNumber == lastCarNumber)
        {
            for (int i = 0; i < carNPC.Length; i++)
            {
                if (!carNPC[i].activeInHierarchy)
                {
                    carNumber = i;
                }
            }
        }
        
    }
}
