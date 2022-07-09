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

}
