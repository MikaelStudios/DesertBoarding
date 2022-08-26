using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform player;
    public TextMeshProUGUI score;
    public int finalScore;
    public int highScore;
    public float addToScore;
    public float speedMultiplier;
    private float distanceX;
    public bool isGameOver;
    public Slider FuelGuage;
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public GameObject shade;
    public GameObject pauseButton;
    public  TextMeshProUGUI bestScore;
    public TextMeshProUGUI finalBestScore;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        finalScore = 0;
        addToScore = 0;
        FuelGuage.maxValue = 10;
        FuelGuage.minValue = 0;
        FuelGuage.value = 10;
        distanceX = player.position.x;
        
        highScore = PlayerPrefs.GetInt("Best Score", finalScore);
        Debug.Log("highScore");
        finalScore = PlayerPrefs.GetInt("Best Score", finalScore);
        score.text = "Score: " + finalScore.ToString("00000");
        

        if(PlayerPrefs.GetInt("FirstTime") == 0)
        {
            PlayerPrefs.SetInt("FirstTime", 1);
            shade.SetActive(true);
            startPanel.SetActive(true);
            Pause();
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.GetInt("Best Score", finalScore);
        if (!isGameOver)
        {
            score.text = "Score: " + (player.position.x - distanceX + addToScore).ToString("0000");
            finalScore = (int)(player.position.x - distanceX + addToScore);
            
        }
       
        if(highScore < finalScore)
            PlayerPrefs.SetInt("Best Score", finalScore);
            finalScore = PlayerPrefs.GetInt("Best Score", finalScore);
            bestScore.gameObject.SetActive(true);
            bestScore.text = "BEST SCORE: "+ finalScore.ToString("00000");
            finalBestScore.text = "BEST SCORE: "+ finalScore.ToString("00000");



    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Play()
    {
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        PlayerPrefs.GetInt("Best Score", finalScore);
        //PlayerPrefs.SetInt("Best Score", highScore);
        isGameOver = true;
        //hasGameStarted = false;
        shade.SetActive(true);
        gameOverPanel.SetActive(true);
        pauseButton.SetActive(false);
        finalBestScore.gameObject.SetActive(true);
    }
}
