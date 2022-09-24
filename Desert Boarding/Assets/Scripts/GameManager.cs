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
    public GameObject confetti;

    public GameObject confettiForDistanceApplaud;
    public GameObject distanceApplaudPanel;
    public TextMeshProUGUI bestScore;
    public TextMeshProUGUI finalBestScore;
    public TextMeshProUGUI finalgameoverScore;

    public GameEvent OnGameOver;
    public FloatEvent OnHighScore;
    public GameObject[] vehicles;

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
        foreach( GameObject veh in vehicles)
        {
            distanceX = veh.transform.position.x;
        }

        
        highScore = PlayerPrefs.GetInt("Best Score", finalScore);
        //PlayerPrefs.DeleteAll();
        finalScore = PlayerPrefs.GetInt("Best Score", finalScore);
        //Debug.Log("highScore"+ finalScore);
        score.text = "Score: " + finalScore.ToString("00000");
        
        //distanceApplaudPanel.SetActive(true);

        /*if(PlayerPrefs.GetInt("FirstTime") == 0)
        {
            PlayerPrefs.SetInt("FirstTime", 1);
            shade.SetActive(true);
            startPanel.SetActive(true);
            Pause();
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.GetInt("Best Score", finalScore);
        if (!isGameOver)
        {
            float newposition = PlayerMovement.instance.distanceX;
            score.gameObject.SetActive(true);
            score.text = "Score: " + ((newposition - distanceX) + addToScore).ToString("0000");
            /*if(score.text =="Score: " +100)
            {
                score.text = "Score: 0000";
            }
            else
            {
                score.text = "Score: " + (100+(newposition - distanceX) + addToScore).ToString("0000");
            }*/
            finalgameoverScore.text = "Score: " + (newposition - distanceX + addToScore).ToString("0000");
            finalScore = (int)(newposition - distanceX + addToScore);
                //Debug.Log("Score"+ finalScore);
            OnHighScore.Raise(newposition - distanceX + addToScore);
            
        }
       
        
        else if(isGameOver)
        {
            confettiForDistanceApplaud.SetActive(false);
            distanceApplaudPanel.SetActive(false);
        }
        if(highScore < finalScore)
        {   PlayerPrefs.SetInt("Best Score", finalScore);
            finalScore = PlayerPrefs.GetInt("Best Score", finalScore);
            bestScore.gameObject.SetActive(true);
            bestScore.text = "BEST SCORE: "+ finalScore.ToString("00000");
            finalBestScore.text = "BEST SCORE: "+ finalScore.ToString("00000");
            Debug.Log("highScore " + highScore);
            Debug.Log("finalScore " + finalScore);
        }
        
    }
    
    /*void LateUpdate()
    {
        if(finalScore > highScore)
           {
              StartCoroutine(DistanceApplaud());
           }
    }*/
    

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
        if(highScore < finalScore)
           confetti.SetActive(true);

        PlayerPrefs.GetInt("Best Score", finalScore);
        isGameOver = true;

        shade.SetActive(true);
        //gameOverPanel.SetActive(true);
        OnGameOver.Raise();
        pauseButton.SetActive(false);
        finalBestScore.gameObject.SetActive(true);
        finalgameoverScore.gameObject.SetActive(true);
        
        //LeaderBoard.Instance.UpdateLeaderboardScore(highScore);
    }

    private IEnumerator DistanceApplaud()
    {
        confettiForDistanceApplaud.SetActive(true);
        yield return new WaitForSeconds(0);
        confettiForDistanceApplaud.SetActive(false);
        distanceApplaudPanel.SetActive(false);
    }
}
