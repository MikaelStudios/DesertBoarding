using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NitroAssets : MonoBehaviour
{
    public ParticleSystem particle;
   
    public void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.CompareTag("Player"))
        {
            particle.Play();
            //Destroy(gameObject);

        }
        
    }
}
