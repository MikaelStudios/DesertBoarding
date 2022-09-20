using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform[] followTransform;

    private void LateUpdate()
    {
        foreach( Transform target in followTransform)

        {
            this.transform.position = new Vector3(target.position.x, target.position.y, this.transform.position.z);
        }
    }
    
}
