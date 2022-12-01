using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoliceStationInteraction : MonoBehaviour
{
    [SerializeField] Text donutInPS;

    [SerializeField] Text DonutCounterOnCop;

    [SerializeField] GameObject donutStore;

    private int donutNumber;

    private void Awake()
    {
        donutNumber = 0;
    }

    public void DonutNumberInPSIncrease()
    {
        if (DonutCounterOnCop.GetComponent<OnCopDonutCounter>().DoesCopHaveDonut())
        {
            donutNumber += 1;
            donutInPS.GetComponent<InPSDonutCounter>().DonutCountInPS(donutNumber);

            DonutCounterOnCop.GetComponent<OnCopDonutCounter>().DonutTransferToPS();

            donutStore.GetComponent<DonutStoreInteraction>().DonutNumberOnCopDicrease();
        }
    }
}
