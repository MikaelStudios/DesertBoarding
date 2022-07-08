using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform player;
    public TextMeshProUGUI score;
    public float speedMultiplier;
    private float distanceX;
    public bool isGameOver;
    public Slider FuelGuage;
    public GameObject gameOverPanel;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        FuelGuage.maxValue = 10;
        FuelGuage.minValue = 0;
        FuelGuage.value = 10;
        distanceX = player.position.x;
        score.text = "score: " + (player.position.x - distanceX).ToString("00000");
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "score: " + (player.position.x - distanceX).ToString("00000");
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
        gameOverPanel.SetActive(true);
    }
}
