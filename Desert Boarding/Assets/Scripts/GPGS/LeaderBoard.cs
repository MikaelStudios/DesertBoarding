using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;

public class LeaderBoard : MonoBehaviour
{
    // the Leaderboard ID as it is on the Google Play Developer Console
    private string KekeRushLeaderboardID = "";

    // Show LeaderBoard - attach this to a button
	public void ShowLeaderBoardBtn() // ! attach this a button that opens the leaderboard
	{
		// Social.ShowLeaderboardUI(); // code to show all Leaderboards

		PlayGamesPlatform.Instance.ShowLeaderboardUI(KekeRushLeaderboardID); // specific Leaderboard
	}

    // Updating each player's Leaderboard Score
	public void UpdateLeaderboardScore()
	{
        // Get the value from anywhere you want
        // ! => Get the value from the game
        var leaderboardScoreValue = "100";

		Social.ReportScore(int.Parse(leaderboardScoreValue), KekeRushLeaderboardID, (bool success) => {
			// handle success or failure
            //if (success){Debug.Log("Score Updated");}
            //else{Debug.Log("Score Not Updated");}
		});
	}
}
