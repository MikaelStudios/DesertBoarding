using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;

public class LeaderBoard : MonoBehaviour
{
	/*public static LeaderBoard Instance;

	private void Awake()
	{
		if (Instance == null)
		   {
		     Instance = this;
			 DontDestroyOnLoad(gameObject);
		   }
		else
		{
			Destroy(gameObject);
		}
	}
    // the Leaderboard ID as it is on the Google Play Developer Console
	[Header("Leaderboard ID")]
    public string KekeRushLeaderboardID;

    // Show LeaderBoard - attach this to a button
	public void ShowLeaderBoardBtn() // ! attach this a button that opens the leaderboard
	{
		// Social.ShowLeaderboardUI(); // code to show all Leaderboards

		Debug.Log("Show LeaderBoard Pressed");

		PlayGamesPlatform.Instance.ShowLeaderboardUI(KekeRushLeaderboardID); // specific Leaderboard
	}

    // Updating each player's Leaderboard Score
	public void UpdateLeaderboardScore(int leaderboardScoreValue )
	{
        // Get the value from anywhere you want
        // ! => Get the value from the game
        // var leaderboardScoreValue = "100";

		Social.ReportScore(leaderboardScoreValue, KekeRushLeaderboardID, (bool success) => {
			// handle success or failure
            //if (success){Debug.Log("Score Updated");}
            //else{Debug.Log("Score Not Updated");}
		});
	}*/
}
