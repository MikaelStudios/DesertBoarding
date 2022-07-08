using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{

    public GameObject[] prefabs;
    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(0, prefabs.Length);
        Vector3 offset = new Vector3(0, 0.15f, 0);
        
        Instantiate(prefabs[random], transform.position - offset, transform.rotation);
    }

//     public GameObject obstacle1, obstacle2, obstacle3;

//     private float spawnInterval = 2f;

//     public float currentSpeed = 5f;

//     void Start()
//     {
//         StartCoroutine("GenerateObstacles");
//     }
    


//     private void SpawnObstacle()
//     {
//       int random = Random.Range(1, 4);  

//     if(random == 1)
//     {
//          Instantiate(obstacle1, new Vector3(transform.position.x, 0.5f, 0), Quaternion.identity);
//          transform.Translate(Vector2.left * 10f * Time.deltaTime);
//     }
//     else if(random == 2)
//     {
//          Instantiate(obstacle1, new Vector3(transform.position.x, 0.5f, 0), Quaternion.identity);
//     }
//     else if(random == 3)
//     {
//          Instantiate(obstacle1, new Vector3(transform.position.x, 0.5f, 0), Quaternion.identity);
//     }

//     }

//  IEnumerator GenerateObstacles()
//  {
//     while(true)
//     {
//         SpawnObstacle();
//         yield return new WaitForSeconds(spawnInterval);
//     }
//  }
}
