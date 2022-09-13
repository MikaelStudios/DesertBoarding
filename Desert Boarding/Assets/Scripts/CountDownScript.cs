using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CountDownScript : MonoBehaviour
{
    public GameObject Countdown;
    // public TextMeshProUGUI CountdownDisplay;

    private void Start()
    {
        StartCoroutine(CountdownToStart());
    }
    IEnumerator CountdownToStart()
    {
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 4f;
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;
            Countdown.gameObject.SetActive(false);
            Time.timeScale = 1;
            // CountdownDisplay.text = CountdownTime.ToString();

            // yield return new WaitForSeconds(1f);

            // CountdownTime--;
        // CountdownDisplay.text = "GO!";
        
        // yield return new WaitForSeconds(1f);

        // CountdownDisplay.gameObject.SetActive(false);
        // Time.timeScale = 1;

    }
}
