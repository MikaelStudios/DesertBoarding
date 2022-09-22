using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    // public GameObject[] Roads;
    //public GameObject currentRoad;
    public Rigidbody2D rigidbody2d;

    // public LayerMask Track;
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

    public float acceleration;

    public GameObject nitrofillobject;
    public Text ProgressIndicator;
    public GameObject OutOfFuelText;
    public Image LoadingBar;
    public Image FuelBar;
    public float currentValue = 100f;
    public float speedfill;
    public GameObject nitroButton;
    public GameObject noNitro;
    public GameObject nitroObject;
    public bool isNitro;
    public bool isNitroempty;
    public bool Onground = true;

    public ParticleSystem nitroparticle;
    public ParticleSystem exhaustparticle;

    public PolygonCollider2D boxCollider2d;

    
    public float speedometer = 0.0f;

    public static PlayerMovement instance;
    Animator anim;
    public GameObject nitroObjectButton, leftbutton, rightbutton, acceleratorbutton;
    public Transform player;
    public float distanceX;
    public float accelerationAmount;
    public float nitroAmount;
    
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
        AudioManager.instance.NormalCarSound();
        isGrounded = true;
        anim = GetComponent<Animator>();
        nitroObjectButton.SetActive(true);
        leftbutton.SetActive(true);
        rightbutton.SetActive(true);
        acceleratorbutton.SetActive(true);
        //PlayerScore();

        
    }

    private void FixedUpdate()
    {

        if (GameManager.Instance.isGameOver){return;}
        
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("CrossTour"))
        {
            rigidbody2d.AddForce(transform.right * runSpeed * Time.fixedDeltaTime * 180f, ForceMode2D.Force);
            
            PlayerRigidbody();
            if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            {
                
                // nitroObjectButton.SetActive(true);
                // leftbutton.SetActive(true);
                // rightbutton.SetActive(true);
                // acceleratorbutton.SetActive(true);
                PlayerScore();
                FlipLeft();
                FlipRight();
                IncreaseSpeed();
                NitroSpeed();
                FuelReduce();

        }
    }
        //rigidbody2d.AddForce(transform.right * runSpeed * Time.fixedDeltaTime * 180f, ForceMode2D.Force);
        // if(Input.GetKey(KeyCode.Space))
        // {
        //     ReduceSpeed();
            
        // }
        // else
        // {
        //     rigidbody2d.AddForce(transform.right * runSpeed * Time.fixedDeltaTime * 250f, ForceMode2D.Force);
            

        // }
        
        
        
    }
    
    // public void JumpUp()
    // {
    //     //rigidbody2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    //             //audioSource.PlayOneShot(jumpSound, 0.9f);
    //     float jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rigidbody2d.gravityScale));
    //     rigidbody2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    //     jumping = true;
    //     jumpCancelled = false;
    //     jumpTime = 0;
                
    //     if (jumping)
    //     {
    //         jumpTime += Time.deltaTime;
    //         if (Input.GetKeyUp(KeyCode.Space))
    //         {
    //             jumpCancelled = true;
    //         }
    //         if (jumpTime > buttonTime)
    //         {
    //             jumping = false;

    //         }
    //     }
            
    // }
    
    public void FlipRight()
    {
        if (IsGrounded() == true && LongPressed.instance.rightButtonDown){
           // Onground = false;
            transform.Rotate(0f, 0f, -2f);
            //if ((transform.rotation.eulerAngles.z > -4) && (transform.rotation.eulerAngles.z < -4))
            
            // RotateBike(Vector3.forward * -2, 0.9f);
            
        }
    }
    
    public void FlipLeft()
    {
        if (IsGrounded() == true && LongPressed.instance.leftButtonDown){
            // Rotate backwards
            
            transform.Rotate(0f, 0f, 4f);
            // RotateBike(Vector3.forward * 1, 1f);
            
        } 
        
    }
    private bool IsGrounded()
    {
        
        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2d.bounds.center, Vector2.down);
        
        Debug.DrawRay(transform.position, Vector2.down);
        if(raycastHit !=null)
        {
            return true;

        }
        return false;
    }
    
    public void IncreaseSpeed()
    {
        
        if (LongPressed.instance.brakeButtonDown)
        {
            FuelBar.fillAmount -= 0.05f* Time.deltaTime;
            rigidbody2d.AddForce(transform.right * runSpeed * Time.fixedDeltaTime * accelerationAmount, ForceMode2D.Force);
            
            AudioManager.instance.StopNormalCarSound();
            AudioManager.instance.PlayCarSound();
            exhaustparticle.Play();
              
            // rigidbody2d.velocity -= rigidbody2d.velocity * 0.1f;
        } 
        else if(!LongPressed.instance.brakeButtonDown)
        {
            AudioManager.instance.StopCarSound(); 
            AudioManager.instance.NormalCarSound();
            exhaustparticle.Stop();

                      
        }
            
        
    }
    
    public void NitroSpeed()
    {
        
        if (LongPressed.instance.nitroButtonDown)
        {
            FuelBar.fillAmount -= 0.08f* Time.deltaTime;
        

            NitroFillCar();
            rigidbody2d.AddForce(transform.right * runSpeed * Time.fixedDeltaTime * nitroAmount, ForceMode2D.Force);
            if(LoadingBar.fillAmount <= 0)
            {
                LongPressed.instance.nitroButtonDown = false;
                
                nitroButton.SetActive(false);
                nitrofillobject.SetActive(false);
                //noNitro.SetActive(true);
            }
            isNitro = true;
            // rigidbody2d.velocity -= rigidbody2d.velocity * 0.1f;
        } 
        else if (!LongPressed.instance.nitroButtonDown)
        {
            nitroparticle.Stop();
            AudioManager.instance.StopNitroCarSound();
            AudioManager.instance.NormalCarSound();
        }
            
        
    }

 
    
    // Update is called once per frame
    public void NitroFillCar() {
        LoadingBar.fillAmount -= speedfill* Time.deltaTime;
        nitroparticle.Play();
        AudioManager.instance.NitroCarSound();
        AudioManager.instance.StopNormalCarSound();
        noNitro.SetActive(false);
        //Debug.Log("currentValue " + currentValue);                
    }
    public void FuelReduce() {
        FuelBar.fillAmount -= 0.02f* Time.deltaTime;
        if(FuelBar.fillAmount == 0)
        {
           GameManager.Instance.GameOver();
           OutOfFuelText.SetActive(true);
        }
            
                        
    }
    public void PlayerScore()
    {
        distanceX = player.position.x;
    }
    public void PlayerRigidbody()
    {
        speedometer = rigidbody2d.velocity.magnitude * 3.6f;
    }
    
    
    /*public void IncreaseSpeed()
    {
        
        if (LongPressed.instance.accelerateButtonDown){
       
            
            rigidbody2d.velocity += acceleration*Time.deltaTime;}
        
            
        
    }*/
    

    
    // private void RotateBike(Vector3 byAngles, float inTime) 
    // {   
    //     var fromAngle = transform.rotation;
    //     var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
    //     for(var t = 0f; t < 1; t += Time.deltaTime/inTime)
    //     {
    //         transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
    //     }
    // }
   

    public IEnumerator IncrementScore()
    {
        IncreaseScore.transform.localScale = new Vector3(2, 0, 1);
       // IncreaseScore.gameObject.SetActive(true);
        //Debug.Log(IncreaseScore.transform.localScale);
        while(IncreaseScore.transform.localScale.y < 2)
        {
            yield return new WaitForSeconds(0.04f);
            IncreaseScore.transform.localScale = new Vector3(IncreaseScore.transform.localScale.x, 
                IncreaseScore.transform.localScale.y + 0.2f, IncreaseScore.transform.localScale.z);
        }
        GameManager.Instance.addToScore += 50;
        yield return new WaitForSeconds(1f);
        //IncreaseScore.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isGrounded = true && collision.collider.CompareTag("road"))
        {
            isGrounded = true;
            /*angleTurned = 0;
            if (possibleFlip)
                StartCoroutine(IncrementScore());
            isGrounded = true;
            possibleFlip = false;
            */
            
            StartCoroutine(IncrementScore());
            
        }
        

        //spawning hills
        // if(collision.collider.CompareTag("track") && collision.gameObject.transform.position != currentTrackPosition)
        // {
        //     //isGrounded = true;
        //     currentTrackPosition = collision.gameObject.transform.position;
        //     float x = collision.gameObject.transform.GetChild(0).transform.position.x;
        //     float y = collision.gameObject.transform.GetChild(0).transform.position.y;
        //     Vector3 target = new Vector3(x + 6, y - 4, 0);
        //     Instantiate(Roads[Random.Range(0, Roads.Length)], target, Quaternion.identity);
        // }

        if (collision.collider.CompareTag("death"))
            GameManager.Instance.GameOver();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.isGameOver)
            return;

        if (collision.CompareTag("fuel"))
        {
            //noNitro.SetActive(false);
            nitroButton.SetActive(true);
            nitrofillobject.SetActive(true);
            LoadingBar.fillAmount += 1f;
        }
        if(collision.CompareTag("topup"))
        {
            FuelBar.fillAmount=1.0f;

        }
    }
}
