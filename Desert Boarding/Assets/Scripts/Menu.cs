using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI highScore;

    private void Start()
    {
        highScore.text = "HighScore\n" + PlayerPrefs.GetInt("HighScore").ToString("00000");
    }

    public void QuitGame()
    {
        //SceneManager.LoadScene("Gameplay Scene");
        Application.Quit();
    }

}
