using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSetUp : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;

    [SerializeField] GameObject player;

    [SerializeField] GameObject playerCar;
    
    private Text timerText;

    [SerializeField] private int timeLeftStartingValue;

    private float timeLeftCurrentValue;

    private void Awake()
    {
        timerText = GetComponent<Text>();

        timerText.text = "Time left : " + timeLeftStartingValue;

        timeLeftCurrentValue = timeLeftStartingValue;

        StartCoroutine(TimerCounterEachSecond());
    }

    private void Update()
    {
        timeLeftCurrentValue = Mathf.Floor(timeLeftCurrentValue); 

        timerText.text = "Time left : " + timeLeftCurrentValue;

        if (timeLeftCurrentValue <= 0)
        {
            gameOverScreen.SetActive(true);

            player.GetComponent<PlayerMovement>().enabled = false;

            playerCar.GetComponent<PlayerCarMovement>().enabled = false;
        }
    }
    private IEnumerator TimerCounterEachSecond()
    {
        for (int i = timeLeftStartingValue; i >= 0; i--)
        { 
            timeLeftCurrentValue = i;
            yield return new WaitForSeconds(1);
        }
        yield return null;
        
    }
}
