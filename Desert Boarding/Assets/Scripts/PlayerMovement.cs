using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public int runSpeed;
    public float speed;
    private bool didTouchMove;
    private float touchLength;
    private float touchBeginTime;
    private float tapTimeLimit = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        didTouchMove = false;
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
         rigidbody2d.AddForce(transform.right * runSpeed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                touchBeginTime = Time.time;
                didTouchMove = false;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                didTouchMove = true;
            }
            if (Time.time - touchBeginTime >= 1.0f)
            {
                transform.Rotate(0, 0, -5);
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                touchLength = Time.time - touchBeginTime;
                if (touchLength <= tapTimeLimit && !didTouchMove)
                    rigidbody2d.AddForce(Vector2.up * speed, ForceMode2D.Force);
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
            rigidbody2d.AddForce(Vector2.up * speed, ForceMode2D.Force);
        //rb.velocity += Vector2.up * speed;

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(0, 0, -5);
    }
}
