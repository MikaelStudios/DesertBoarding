using UnityEngine;

public class Obstacle : MonoBehaviour
{
  
  private void OnCollisionEnter(Collision collision)
    {
       if(collision.transform.tag == "track")
        {
          Debug.Log("Hit");
        }
    }
   
}
