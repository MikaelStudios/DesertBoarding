using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource carStopClip;
    public AudioSource carClip;
    public AudioSource carSound;
    public AudioSource nitroSound;
    public AudioSource bombSound;
    public AudioSource countdown;
    
<<<<<<< HEAD
    

=======
>>>>>>> 768dcffdc96f48d768c9f56df336ffbe287e9065
    public static AudioManager instance;
    
    public void Awake()
    {
        instance = this;
    }
    
    public void Update()
    {
        
    }


    public void PlayCarSound()
    {
        carClip.Play();
    }
    public void StopCarSound()
    {
        carClip.Stop();
    }
    public void NormalCarSound()
    {
        carSound.Play();
    }
    public void StopNormalCarSound()
    {
        carSound.Stop();
    }

    public void BombCarSound()
    {
        bombSound.Play();
    }
    public void StopBombCarSound()
    {
        bombSound.Stop();
    }

    public void NitroCarSound()
    {
        nitroSound.Play();
    }
    public void StopNitroCarSound()
    {
        nitroSound.Stop();
    }
    public void PlayCountDown()
    {
        countdown.Play();
    }
}
