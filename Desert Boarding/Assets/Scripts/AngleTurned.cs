using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AngleTurned : MonoBehaviour
{
    private int numFrontFlips = 0;
    private int numBackFlips = 0;
    private bool currentlyOnGround = true;
    private float totalRotation = 0f;
    private Quaternion lastRotation;
    public TextMeshProUGUI angle;
    public void Update()
    {
        /*if(IsGrounded()) 
        {
            // we are on the ground no need to check rotations
            return;
        }*/

    // we are in the air, were we on the ground last frame?
        if(!currentlyOnGround)
        {
          // last frame we were still on the ground, we need to initialize our tracking variables
            Initialize();
        }

        // we are in the air, and all the initialization is done, now check for flips

        // to get the difference between to Quaterions we can multiply A with the inverse of B
        Quaternion rotationDifference = transform.rotation * Quaternion.Inverse(lastRotation);
        // we now have the difference as quaternion, convert it to euler angles and take the x component
        totalRotation += rotationDifference.eulerAngles.x;
        angle.text = "rotation: " + totalRotation;

        // now check if we did a full front/back flip
        if(totalRotation > 90f)
        {
            // full front flip
            numFrontFlips += 1;
            Debug.Log("frontflipped: " + numFrontFlips);
            // reset the tracked variables, to start the next flip
            Initialize();
        } 
        if(totalRotation < -90f)
        {
            // full back flip
            numBackFlips += 1;
            // reset the tracked variables, to start the next flip
            Initialize();
        } 
    }
    private void Initialize() 
    {
        // reset the tracked rotation
        totalRotation = 90f;
        // start tracking the last rotation
        lastRotation = transform.rotation;
    }
    //private bool IsGrounded()
    //{
        // check online for how to do that
    //}
}


















































































    