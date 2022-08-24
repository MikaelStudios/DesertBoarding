using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Breakable : MonoBehaviour
{
   private ParticleSystem particle;
   private SpriteRenderer spriteRenderer;
   private BoxCollider2D boxCollider;
   public GameObject mainObject;


   private void Awake()
   {
      particle = GetComponentInChildren<ParticleSystem>();
      spriteRenderer = GetComponent<SpriteRenderer>();
      boxCollider = GetComponent<BoxCollider2D>();
   }


   /*private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.collider.gameObject.GetComponent<PlayerMovement>() && 
      other.contacts[0].normal.x > 0.5f) 
      {
          StartCoroutine(Break());
      }
   }*/
   public void OnTriggerEnter2D(Collider2D collision)
   {
        

      if (collision.CompareTag("Player"))
      {
         bool isNitro = PlayerMovement.instance.isNitro;
         if(isNitro)
         {
            Destroy(gameObject);
            
               
         }
         
      }
        
    }
   
   
   private IEnumerator Break()
   {
     particle.Play();
     spriteRenderer.enabled = false;
     yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
     Destroy(gameObject); 
   }
}
