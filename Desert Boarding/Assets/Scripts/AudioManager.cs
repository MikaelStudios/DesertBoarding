using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource carStopClip;
    public AudioSource carClip;

    public static AudioManager instance;
    
    public void Awake()
    {
        instance = this;
    }

    public void PlayCarSound()
    {
        carClip.Play();
    }
    public void StopCarSound()
    {
        carClip.Stop();
    }
}
