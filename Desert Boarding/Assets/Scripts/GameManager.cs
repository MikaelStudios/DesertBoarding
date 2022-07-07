using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI score;
    private float distanceX;

    // Start is called before the first frame update
    void Start()
    {
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
}
