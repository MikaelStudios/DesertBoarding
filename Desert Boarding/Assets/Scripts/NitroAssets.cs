using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NitroAssets : MonoBehaviour
{
    public ParticleSystem particle;

    public AudioSource audioSource;
   
    public void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.CompareTag("Player"))
        {
            
            StartCoroutine(Destroy());
            particle.Play();
            audioSource.Play();

        }
        
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
