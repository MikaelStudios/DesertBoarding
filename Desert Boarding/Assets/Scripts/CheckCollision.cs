using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    public ParticleSystem explosionParticles;
    
    void OnCollisionEnter2D (Collision2D collisionInfo)
    {
        
        if(collisionInfo.gameObject.tag == "road")
        {
            explosionParticles.Play();

            AudioManager.instance.StopCarSound();
            AudioManager.instance.StopNitroCarSound();
            AudioManager.instance.StopNormalCarSound();
            AudioManager.instance.BombCarSound();
            StartCoroutine(GameOver(1.3f));
      
            
        }
        AudioManager.instance.StopBombCarSound();
        AudioManager.instance.NormalCarSound();
        
    }
    public IEnumerator GameOver(float numSeconds)
    {
            
        yield return new WaitForSeconds(numSeconds);
        GameManager.Instance.GameOver();
        
         
   }
 
}
