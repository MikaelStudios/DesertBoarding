using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{

    
    void OnCollisionEnter2D (Collision2D collisionInfo)
    {
        
        if(collisionInfo.gameObject.tag == "road")
        {
            GameManager.Instance.Explode();
            GameManager.Instance.GameOver();
        }
    }
 
}
