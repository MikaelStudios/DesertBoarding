using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveData : MonoBehaviour
{
    public static SaveData Instance;

    public TextMeshProUGUI myName;
    public int finalScore;
    public int myScore = 1000;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendScore()
    {
        
        if (0 < PlayerPrefs.GetInt("Best Score", finalScore))
            PlayerPrefs.SetInt("Best Score", finalScore);
            HighScores.UploadScore(myName.text, PlayerPrefs.GetInt("Best Score", finalScore));
    }
}
