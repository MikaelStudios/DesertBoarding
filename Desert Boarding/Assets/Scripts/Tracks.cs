using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 2; i < transform.childCount - 1; i++)
        {
            //Debug.Log("hello");
            if (Random.Range(0, 1f) > 0.5f)
                transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.currentTrackPosition.x - transform.position.x > 100)
            Destroy(gameObject);
    }
}
