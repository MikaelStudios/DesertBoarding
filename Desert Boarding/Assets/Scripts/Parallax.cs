using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    //public GameObject cam;
    public Transform player;
    public float parallaxEffect;

    private void Start()
    {
        //startpos = transform.position.x;
        startpos = player.transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        startpos = player.transform.position.x;
        float temp = transform.position.x;
        transform.Translate(Vector3.left * (1 - parallaxEffect) * 0.05f * 2.5f);
        if (temp < startpos - length) transform.position = new Vector3(startpos, PlayerMovement.currentTrackPosition.y, transform.position.z);
    }
}
