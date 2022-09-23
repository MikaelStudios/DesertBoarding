using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CountTimer : MonoBehaviour
{
    public float timeRemaining = 10;

    public bool timerIsRunning = false;
    public TextMeshProUGUI disvar;
    public AudioSource countdown;
    public GameObject countdownPanel;

    private void Start()

    {

        // Starts the timer automatically

        timerIsRunning = true;
        countdown.Play();
        countdownPanel.SetActive(true);

    }

    void Update()

    {

        StartCoroutine(ShowCountDown(0.5f));

       


    }
    public void CountDown()
    {

        if (timerIsRunning)
        {

            if (timeRemaining > 0)
            {

                timeRemaining -= Time.deltaTime;
                if(timeRemaining == 0){
                    disvar.text = "GO!";
                }
                Debug.Log("timeRemaining" +timeRemaining);

            }

            double b = System.Math.Round (timeRemaining); 
            disvar.text = b.ToString ();

            if(timeRemaining<0)

            {

                Debug.Log("Time has run out!");

                timeRemaining = 0;

                timerIsRunning = false;
                countdownPanel.SetActive(false);

            }
        }
    }
    public IEnumerator ShowCountDown(float time)
    {
        yield return new WaitForSecondsRealtime(time);

        CountDown();
    }
}
