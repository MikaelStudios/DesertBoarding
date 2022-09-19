using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform[] target;
    //public GameObject vehicle;

    public Vector3 offset;

    private void LateUpdate()
    {
        foreach (Transform veh in target)
        {
            Vector3 newPos = veh.position + offset;
            newPos.z = transform.position.z;
            transform.position = newPos;
        }
    }
    
}
