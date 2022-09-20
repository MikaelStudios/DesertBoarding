using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    public Transform[] paths;
    public Vector3 nextPathPosition;
    public GameObject player;
    public float pathDrawDistance;
    public float pathDeleteDistance;

    // Transform target;

    // Start is called before the first frame update
    void Start()
    {
        LoadParts();
        // target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        RemoveParts();
        LoadParts();
    }

    void LoadParts()
    {
        while ((nextPathPosition - player.transform.position).x < pathDrawDistance)
        {
            Transform path = paths[Random.Range(0, paths.Length)];
            
            Transform newPath = Instantiate(path, nextPathPosition - path.Find("startpoint").position, path.rotation, transform);

            nextPathPosition = newPath.Find("endpoint").position;
        }
    }

    void RemoveParts()
    {
        if(transform.childCount > 0)
        {
            Transform path = transform.GetChild(0);
            Vector3 diff = player.transform.position - path.position;

            if(diff.x > pathDeleteDistance)
            {
                Destroy(path.gameObject);
            }
        }
    }
}
