using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject[] Roads;
    //public GameObject currentRoad;
    public Rigidbody2D rigidbody2d;

    public LayerMask Track;
    public TextMeshProUGUI IncreaseScore;
    public Transform floorPoint;
    public Transform deathPoint;
    public float floorCheckRadius;
    public float deathCheckRadius;
    public int runSpeed;
    public int angleTurned;
    public float speed;
    public static Vector3 currentTrackPosition;
    private bool didTouchMove;
    public bool isGrounded;
    public bool possibleFlip;
    private float touchLength;
    private float touchBeginTime;
    private float tapTimeLimit = 0.2f;
    public float forceamount = 10f;

    public AudioClip jumpSound;
    public AudioClip pickupSound;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        angleTurned = 0;
        currentTrackPosition = new Vector3(-1, -1, -1);
        didTouchMove = false;
        rigidbody2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!GameManager.Instance.isGameOver)
        {
            rigidbody2d.AddForce(transform.right * runSpeed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);

            /*if (Input.touchCount > 0)
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
                if (Time.time - touchBeginTime >= 0.3f && !isGrounded)
                {
                    angleTurned -= 5;
                    transform.Rotate(0, 0, -5);
                    //rigidbody2d.AddForce(transform.right * runSpeed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
                }
                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    angleTurned = 0;
                    touchLength = Time.time - touchBeginTime;
                    if (touchLength <= tapTimeLimit && !didTouchMove && isGrounded)
                    {
                        rigidbody2d.AddForce(Vector2.up * speed, ForceMode2D.Force);
                        audioSource.PlayOneShot(jumpSound);
                    }
                }
            }

            if (GameManager.Instance.FuelGuage.value - 0.01f > 0 && isGrounded)
                GameManager.Instance.FuelGuage.value -= 0.01f;
            else if (isGrounded)
            {
                GameManager.Instance.FuelGuage.value = 0;
                GameManager.Instance.GameOver();
            }*/

            /*if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
            {
                rigidbody2d.AddForce(Vector2.up * speed, ForceMode2D.Force);
                audioSource.PlayOneShot(jumpSound, 1f);
                //rb.velocity += Vector2.up * speed;
            }

            if (Input.GetKey(KeyCode.RightArrow) && !isGrounded)
            {
                angleTurned -= 2;
                transform.Rotate(0, 0, -2);
            }
            if (Input.GetKey(KeyCode.LeftArrow) && !isGrounded)
            {
                angleTurned += 2;
                transform.Rotate(0, 0, 2);
            }*/

            if (!Physics2D.OverlapCircle(floorPoint.position, floorCheckRadius, Track))
            {
                isGrounded = false;
                /*if (currentTrackPosition.y - transform.position.y > 10)
                    GameManager.Instance.GameOver();*/
            }

            if (Physics2D.OverlapCircle(deathPoint.position, deathCheckRadius, Track))
                GameManager.Instance.GameOver();

            if (angleTurned <= -180)
                possibleFlip = true;
        }

        /*if (GameManager.Instance.isGameOver && !GameManager.Instance.hasGameStarted)
            transform.position = new Vector3(-7, -0.4f, 0);*/
    }
    public void JumpUp()
    {
        if (isGrounded)
            {
                rigidbody2d.AddForce(Vector2.up * forceamount, ForceMode2D.Force);
                audioSource.PlayOneShot(jumpSound, 1f);
                //rb.velocity += Vector2.up * speed;
            }
    }
    public void FlipRight()
    {
        if (!isGrounded)
            {
                StartCoroutine(RotateBike(Vector3.forward * -23, 0.8f));
            }

    }
    public void FlipLeft()
    {
        if (!isGrounded)
            {
                StartCoroutine(RotateBike(Vector3.forward * 23, 0.8f));
            }
    }

    IEnumerator RotateBike(Vector3 byAngles, float inTime) 
    {   var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for(var t = 0f; t < 1; t += Time.deltaTime/inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
    }

    public IEnumerator IncrementScore()
    {
        IncreaseScore.transform.localScale = new Vector3(2, 0, 1);
        IncreaseScore.gameObject.SetActive(true);
        //Debug.Log(IncreaseScore.transform.localScale);
        while(IncreaseScore.transform.localScale.y < 2)
        {
            yield return new WaitForSeconds(0.04f);
            IncreaseScore.transform.localScale = new Vector3(IncreaseScore.transform.localScale.x, 
                IncreaseScore.transform.localScale.y + 0.2f, IncreaseScore.transform.localScale.z);
        }
        GameManager.Instance.addToScore += 100;
        yield return new WaitForSeconds(0.5f);
        IncreaseScore.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("track"))
        {
            angleTurned = 0;
            if (possibleFlip)
                StartCoroutine(IncrementScore());
            isGrounded = true;
            possibleFlip = false;
        }

        //spawning hills
        if(collision.collider.CompareTag("track") && collision.gameObject.transform.position != currentTrackPosition)
        {
            //isGrounded = true;
            currentTrackPosition = collision.gameObject.transform.position;
            float x = collision.gameObject.transform.GetChild(0).transform.position.x;
            float y = collision.gameObject.transform.GetChild(0).transform.position.y;
            Vector3 target = new Vector3(x + 6, y - 4, 0);
            Instantiate(Roads[Random.Range(0, Roads.Length)], target, Quaternion.identity);
        }

        if (collision.collider.CompareTag("death"))
            GameManager.Instance.GameOver();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.isGameOver)
            return;

        if (collision.CompareTag("fuel"))
        {
            if (GameManager.Instance.FuelGuage.value + 2 <= 10)
                GameManager.Instance.FuelGuage.value += 2;
            else
                GameManager.Instance.FuelGuage.value = 10;
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(pickupSound, 1f);
        }
    }
}
