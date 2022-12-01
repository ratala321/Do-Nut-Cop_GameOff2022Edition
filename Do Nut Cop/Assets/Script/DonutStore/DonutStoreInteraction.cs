using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DonutStoreInteraction : MonoBehaviour
{
    [SerializeField] Text donutOnCop;

    private int donutNumber;

    private void Awake()
    {
        donutNumber = 0;
    }

    public void DonutNumberOnCopIncrease()
    {
        donutNumber = Mathf.Clamp(donutNumber + 1, 0, 3);
        donutOnCop.GetComponent<OnCopDonutCounter>().DonutCountOnCop(donutNumber);
    }

    public void DonutNumberOnCopDicrease()
    {
        donutNumber = Mathf.Clamp(donutNumber - 1, 0, 3);
    }
}
