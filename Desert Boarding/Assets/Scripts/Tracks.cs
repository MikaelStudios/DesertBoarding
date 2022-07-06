using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.currentTrackPosition.x - transform.position.x > 100)
            Destroy(gameObject);
    }
}
