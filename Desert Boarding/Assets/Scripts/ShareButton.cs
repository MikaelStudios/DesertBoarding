using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ShareButton : MonoBehaviour
{

// void Update()
// {
// 	if( Input.GetMouseButtonDown( 0 ) )
// 		StartCoroutine( TakeScreenshotAndShare() );
// }
private string shareMessage;

public int finalScore;
public int highScore;

void Start()
{
     highScore = PlayerPrefs.GetInt("Best Score", finalScore);
     Debug.Log(highScore);
        
}

public void PressToShare()
{
    shareMessage = "Whoa! i can't believe i scored " + highScore.ToString() + " in  Keke Rush!";

    StartCoroutine(TakeScreenshotAndShare());
}

private IEnumerator TakeScreenshotAndShare()
{
	yield return new WaitForEndOfFrame();

	Texture2D ss = new Texture2D( Screen.width, Screen.height, TextureFormat.RGB24, false );
	ss.ReadPixels( new Rect( 0, 0, Screen.width, Screen.height ), 0, 0 );
	ss.Apply();

	string filePath = Path.Combine( Application.temporaryCachePath, "shared img.png" );
	File.WriteAllBytes( filePath, ss.EncodeToPNG() );

	// To avoid memory leaks
	Destroy( ss );

	new NativeShare().AddFile( filePath )
		.SetSubject( "Keke Rush" ).SetText( shareMessage ).SetUrl( "https://github.com/yasirkula/UnityNativeShare" )
		.SetCallback( ( result, shareTarget ) => Debug.Log( "Share result: " + result + ", selected app: " + shareTarget ) )
		.Share();

	// Share on WhatsApp only, if installed (Android only)
	//if( NativeShare.TargetExists( "com.whatsapp" ) )
	//	new NativeShare().AddFile( filePath ).AddTarget( "com.whatsapp" ).Share();
}
}
