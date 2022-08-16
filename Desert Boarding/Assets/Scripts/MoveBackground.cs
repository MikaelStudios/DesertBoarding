using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private float startPosition, length;
    public GameObject mainCamera;
    public float parallaxeffect;
    // Start is called before the first frame update
    void Start()
    {
        
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp= (mainCamera.transform.position.x * parallaxeffect *(1 - parallaxeffect));
        float distance= (mainCamera.transform.position.x * parallaxeffect);
        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);
        if(temp>startPosition+length) startPosition += length;
        else if(temp<startPosition-length) startPosition -= length;
    }
}
