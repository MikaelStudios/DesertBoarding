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
    public float jumpForce;
    public static Vector3 currentTrackPosition;
    private bool didTouchMove;
    public bool isGrounded;
    public bool possibleFlip;
    public  bool flipright;
    public  bool flipleft;
    private float touchLength;
    private float touchBeginTime;
    private float tapTimeLimit = 0.2f;

    public AudioClip jumpSound;
    public AudioClip pickupSound;
    AudioSource audioSource;

    public float jumpHeight = 500;
    float jumpTime;
    bool jumping;
    bool jumpCancelled;
    public float buttonTime = 0.5f;

    


    public static PlayerMovement instance;
    
    public void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        angleTurned = 0;
        currentTrackPosition = new Vector3(-1, -1, -1);
        didTouchMove = false;
        rigidbody2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.isGameOver){return;}

        FlipLeft();
        FlipRight();
        ReduceSpeed();
        
    
        
        
        
        //rigidbody2d.AddForce(transform.right * runSpeed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
        if(Input.GetKey(KeyCode.Space))
        {
            ReduceSpeed();
            
        }
        else
        {
            rigidbody2d.AddForce(transform.right * runSpeed * Time.fixedDeltaTime * 200f, ForceMode2D.Force);
        }
        
        
    }
    
    public void JumpUp()
    {
        if (isGrounded)
            {
                //rigidbody2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                //audioSource.PlayOneShot(jumpSound, 0.9f);
                float jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rigidbody2d.gravityScale));
                rigidbody2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                jumping = true;
                jumpCancelled = false;
                jumpTime = 0;
                
                if (jumping)
                {
                    jumpTime += Time.deltaTime;
                    if (Input.GetKeyUp(KeyCode.Space))
                    {
                        jumpCancelled = true;
                    }
                    if (jumpTime > buttonTime)
                    {
                        jumping = false;
                    }
                }
                //rb.velocity += Vector2.up * speed;
            }
    }
    
    public void FlipRight()
    {
        if (LongPressed.instance.rightButtonDown){
            Debug.Log("TRUERIGHT");
            RotateBike(Vector3.forward * -2, 0.9f);
            
        }
    }
    
    public void FlipLeft()
    {
        if (LongPressed.instance.leftButtonDown){
            // Rotate backwards
            
            RotateBike(Vector3.forward * 2, 1f);
            Debug.Log("TRUE");
            
        } 
        
    }
    
    public void ReduceSpeed()
    {
        if (LongPressed.instance.brakeButtonDown){
            rigidbody2d.velocity -= rigidbody2d.velocity * 0.1f;}
            
        
    }
    

    
    private void RotateBike(Vector3 byAngles, float inTime) 
    {   
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for(var t = 0f; t < 1; t += Time.deltaTime/inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
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
