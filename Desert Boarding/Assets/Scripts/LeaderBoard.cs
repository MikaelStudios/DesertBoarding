using Lean.Gui;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MyClass
{
    public string username;
    public string score;
    public string test;
}

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private int NumberOfPlayersOnScoreboard = 5;
    public TextMeshProUGUI TotalPointsText;
    public GameObject ScoreHolder;
    public Transform Placehaolder;
    public Color UserColor;
    private List<TextMeshProUGUI> Lines = new List<TextMeshProUGUI>();
    private List<TextMeshProUGUI> Scores = new List<TextMeshProUGUI>();

    public LeanButton SubmitButton;
    public LeanWindow LoadingWindow;
    public LeanWindow ErrorWindow;
    public LeanWindow NameWindow;
    public LeanWindow CelebrationWindow;
    public LeanPulse Notification;
    public LeanPulse NameNotification;
    private string UserName;
    private int TotalScore = 0;

    public Lean.Gui.LeanPulse Notification1;
    dreamloLeaderBoard dl;

    //public Object[] tiles = {}
    // Use this for initialization
  
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            dl.AddScore("Hennessy", 4165);
            dl.AddScore("Emmanuel", 4010);
            dl.AddScore("Karlson", 3373);
            dl.AddScore("Momsi", 2910);
            dl.AddScore("Betrams", 2870);
            dl.AddScore("Opeoluzy", 2595);
            dl.AddScore("Daniel", 2315);
            dl.AddScore("Bee", 1940);
            dl.AddScore("Mr Awesome", 715);
            dl.AddScore("Micheal", 620);
            dl.AddScore("John", 620);
            dl.AddScore("Tee", 230);
            dl.AddScore("Tobi-OG", 115);
            dl.AddScore("Preshy Jones", 725);
            dl.AddScore("Milk Boy", 867);



            StartCoroutine(GetScoresAfterAdd());
        }
    }
    public void SetName(TMP_InputField tin)
    {
        if (tin.text == string.Empty)
        {
            Notification.Pulse();
            // send a greeting notification
            return;
        }
        if (dl.HasName(tin.text) || tin.text.ToCharArray()[0] == '<')
        {
            tin.text = string.Empty;
            NameNotification.Pulse();
            return;
        }
        PlayerPrefs.SetString("PlayerName", tin.text);
        PlayerPrefs.Save();
        UserName = tin.text;
        dl.AddScore(tin.text, TotalScore);
        StartCoroutine(GetScoresAfterAdd());
    }
    IEnumerator Start()
    {
        dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard();
        UserName = PlayerPrefs.GetString("PlayerName", string.Empty);
        for (int i = 0; i < 100; i++)
        {
            int Score = PlayerPrefs.GetInt("Level " + i, 0);
            if (Score == 0)
                break;
            TotalScore += Score;
        }
        for (int i = 0; i < NumberOfPlayersOnScoreboard; i++)
        {
            GameObject s = Instantiate(ScoreHolder, Placehaolder);
            Lines.Add(s.transform.GetChild(2).GetComponent<TextMeshProUGUI>());
            Scores.Add(s.transform.GetChild(3).GetComponent<TextMeshProUGUI>());
            Lines[i].text = (i + 1).ToString() + ". ----";
            Scores[i].text = "----";

        }
        TotalPointsText.text += TotalScore.ToString();
        LeanButton btn = SubmitButton.GetComponent<LeanButton>();
        btn.OnClick.AddListener(TaskOnClick);
        LoadingWindow.TurnOn();
        yield return StartCoroutine(dl.GetScoresDelay());
        LoadingWindow.TurnOff();
        List<dreamloLeaderBoard.Score> scoreList = dl.ToListHighToLow();
        if (scoreList == null || scoreList.Count == 0)
        {
            ErrorWindow.TurnOn();
            ErrorWindow.GetComponentInChildren<Text>().text += "Network Error!! Unable to connect to Host";
            yield break;
        }
        int count = 0;
        foreach (dreamloLeaderBoard.Score currentScore in scoreList)
        {
            if (string.Equals(currentScore.playerName.Replace("+", " "), UserName))
            {
                Debug.Log("Found U");
                Lines[count].transform.parent.GetChild(1).GetComponent<Image>().color = UserColor;
            }
            Lines[count].text = (count + 1).ToString() + ". " + currentScore.playerName.Replace("+", " ");
            Scores[count].text = currentScore.score.ToString();
            count++;
            if (count > NumberOfPlayersOnScoreboard - 1)
                break;
        }

        // StartCoroutine(Stuff());

    }
   
    void TaskOnClick()
    {
        if (UserName == string.Empty)
        {
            NameWindow.TurnOn();
            return;
        }
        bool t = dl.AddScore(UserName, TotalScore);
        if (!t)
        {
            Notification1.Pulse();
            return;
        }
        StartCoroutine(GetScoresAfterAdd());
        //LoadLevel(4);
    }

    IEnumerator GetScoresAfterAdd()
    {
        LoadingWindow.TurnOn();
        yield return new WaitForSeconds(2);
        yield return StartCoroutine(dl.GetScoresDelay());
        NameWindow.TurnOff();
        LoadingWindow.TurnOff();
        List<dreamloLeaderBoard.Score> scoreList = dl.ToListHighToLow();
        if (scoreList == null || scoreList.Count == 0 || scoreList[0].playerName.ToCharArray()[0] == '<')
        {
            ErrorWindow.TurnOn();
            ErrorWindow.GetComponentInChildren<Text>().text += "Network Error!! Unable to connect to Host";
            yield break;
        }
        if (dl.GetRank(UserName) == 0) yield break;
        CelebrationWindow.TurnOn();
        if (dl.GetRank(UserName) == 0)
            CelebrationWindow.GetComponentInChildren<TextMeshProUGUI>().text = "Your Points: \n" + TotalScore;
        else
            CelebrationWindow.GetComponentInChildren<TextMeshProUGUI>().text += dl.GetRank(UserName);
    }

}
