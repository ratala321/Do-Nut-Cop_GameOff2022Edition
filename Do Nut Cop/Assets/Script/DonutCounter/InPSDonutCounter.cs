using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InPSDonutCounter : MonoBehaviour
{
    private Text donutCounterText;

    private int numberOfDonutsInPS;

    private void Awake()
    {
        donutCounterText = GetComponent<Text>();
    }

    private void Update()
    {
        donutCounterText.text = "Donuts in PS : " + numberOfDonutsInPS;

    }

    public void DonutCountInPS(int _numberOfDonuts)
    {
        numberOfDonutsInPS = _numberOfDonuts;
    }
}
