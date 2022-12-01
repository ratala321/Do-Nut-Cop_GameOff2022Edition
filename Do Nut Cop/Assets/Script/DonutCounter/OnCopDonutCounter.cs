using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnCopDonutCounter : MonoBehaviour
{
    private Text donutCounterText;

    private int numberOfDonutsOnCop;

    private void Awake()
    {
        donutCounterText = GetComponent<Text>();
    }

    private void Update()
    {
        donutCounterText.text = "Donuts on Cop : " + numberOfDonutsOnCop;

    }

    public void DonutCountOnCop(int _numberOfDonuts)
    {
            numberOfDonutsOnCop = _numberOfDonuts;
    }

    public bool DoesCopHaveDonut()
    {
        if(numberOfDonutsOnCop != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void DonutTransferToPS()
    {
        numberOfDonutsOnCop = Mathf.Clamp(numberOfDonutsOnCop - 1, 0, 99999999);
    }
}
