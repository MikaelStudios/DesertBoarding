using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Coin : MonoBehaviour
{
    public int coin  = 5;
    public int score;
    public TextMeshProUGUI CoinScore;
    public static Coin Instance;
    private void Awake()
    {
        Instance = this;
        GetComponent<Collider2D>().isTrigger = true;
    }
    void Update()
    {
       
        



    }
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            
        
            coin += 5;
            Debug.Log("You currently have " + coin + " Coins.");
            Destroy(gameObject);

               

            /*if (GameManager.Instance.FuelGuage.value + 2 <= 10)
                GameManager.Instance.FuelGuage.value += 2;
            else
                GameManager.Instance.FuelGuage.value = 10;
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(pickupSound, 1f);
        */
        }
        
    }
}
