using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public int runSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rigidbody2d.AddForce(transform.right * runSpeed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
    }
}
