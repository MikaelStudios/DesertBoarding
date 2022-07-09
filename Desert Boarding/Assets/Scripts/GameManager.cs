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
    public float addToScore;
    public float speedMultiplier;
    private float distanceX;
    public bool isGameOver;
    public Slider FuelGuage;
    public GameObject gameOverPanel;
    public GameObject shade;
    public GameObject pauseButton;

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
        score.text = "score: " + (player.position.x - distanceX).ToString("00000");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            score.text = "score: " + (player.position.x - distanceX + addToScore).ToString("00000");
            finalScore = (int)(player.position.x - distanceX + addToScore);
        }
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
        PlayerPrefs.SetInt("HighScore", finalScore);
        isGameOver = true;
        //hasGameStarted = false;
        shade.SetActive(true);
        gameOverPanel.SetActive(true);
        pauseButton.SetActive(false);
    }
}
