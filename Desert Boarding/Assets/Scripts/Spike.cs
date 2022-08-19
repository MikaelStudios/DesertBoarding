using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
   public ParticleSystem explosionParticles;

    private void OnCollisionEnter2D (Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
           explosionParticles.Play();
           AudioManager.instance.StopCarSound();
           StartCoroutine(GameOverDelay(1.3f));  
        }

    }

    public IEnumerator GameOverDelay(float numSeconds)
    {
            
        yield return new WaitForSeconds(numSeconds);
        GameManager.Instance.GameOver();     
   }
}
