using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveData : MonoBehaviour
{
    public static SaveData Instance;

    public TextMeshProUGUI myName;
    public TextMeshProUGUI enterName;
    public int finalScore;
    public int highScore;
    public int myScore = 1000;
    public Button submitButton;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("Best Score", finalScore);
        Debug.Log(highScore);
        submitButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Submit();
    }

    public void SendScore()
    {
        finalScore = PlayerPrefs.GetInt("Best Score", finalScore);
        if (highScore < finalScore)
            submitButton.gameObject.SetActive(true);
            PlayerPrefs.SetInt("Best Score", finalScore);
            HighScores.UploadScore(myName.text, finalScore);
    }
    public void Submit()
    {
        enterName.text = " "+ myName;
    }
}
