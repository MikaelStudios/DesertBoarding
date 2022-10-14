using UnityEngine;
using GooglePlayGames;
using UnityEngine.UI;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class GPGSManager : MonoBehaviour
{
    // Play Games Configuration
    /*private PlayGamesClientConfiguration clientConfiguration;

    // UI Info and Status Texts
    public Text status;
    public Text info;

    void Start()
    {
        ConfigureGPGS();
        SignIntoGPGS(SignInInteractivity.CanPromptOnce, clientConfiguration);
    }

    internal void ConfigureGPGS()
    {
        clientConfiguration = new PlayGamesClientConfiguration.Builder().Build();
    }

    internal void SignIntoGPGS(SignInInteractivity interactivity, PlayGamesClientConfiguration configuration)
    {
        configuration = clientConfiguration;
        PlayGamesPlatform.InitializeInstance(configuration);
        PlayGamesPlatform.Activate();

        PlayGamesPlatform.Instance.Authenticate(interactivity, (code) => 
        {
            status.text = "Authenticating";

            // Debug Text
            Debug.Log("# Authenticating...");

            if(code == SignInStatus.Success)
            {
                status.text = "Successfully Authenticated!";
                info.text = "Hello " + Social.localUser.userName;

                // Debug Text
                Debug.Log("# Successfully Authenticated!!");
                Debug.Log("--");
                Debug.Log("# Hello " + Social.localUser.userName);
            }
            else 
            {
                status.text = "Failed to Authenticate!";
                info.text = "Failed due to " + code;

                // Debug Text
                Debug.Log("Failed to Authenticate due to " + code);    
            }
        });
    }

    // Sign In Button
    public void BasicSignInBtn()
    {
        SignIntoGPGS(SignInInteractivity.CanPromptAlways, clientConfiguration);
    }

    // Sign Out Button
    public void SignOutBtn()
    {
        PlayGamesPlatform.Instance.SignOut();
        status.text = "# Signed Out Successfully";
        info.text = "";

        // Debug Text
        Debug.Log("# Signed Out Successfully");
    }*/
}