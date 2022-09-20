using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    public Transform[] paths;
    public Vector3 nextPathPosition;
    public GameObject[] player;
    public float pathDrawDistance;
    public float pathDeleteDistance;
    public int currentIndex;

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
        currentIndex = PlayerPrefs.GetInt("currentIndex", 0);
        foreach (GameObject vehicle in player)
        {
            while ((nextPathPosition - vehicle.transform.position).x < pathDrawDistance)
            {
                Transform path = paths[Random.Range(0, paths.Length)];
                
                Transform newPath = Instantiate(path, nextPathPosition - path.Find("startpoint").position, path.rotation, transform);

                nextPathPosition = newPath.Find("endpoint").position;
            }
        }
    }

    void RemoveParts()
    {
        if(transform.childCount > 0)
        {
            foreach (GameObject vehicle in player)
            { 
                Transform path = transform.GetChild(0);
                Vector3 diff = vehicle.transform.position - path.position;

                if(diff.x > pathDeleteDistance)
                {
                    Destroy(path.gameObject);
                }
            }
        }
    }
}
