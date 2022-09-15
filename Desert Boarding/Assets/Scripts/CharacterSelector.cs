using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class CharacterSelector : MonoBehaviour
{
    
    public static int currentIndex;
    public GameObject[] vehicleModels;
    public VehiclesBluePrint[] vehicles;
    public static CharacterSelector instance;
    public Button buyButton;
    
    public int finalScore;
    public TextMeshProUGUI nameofCar;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
        
        
        finalScore = PlayerPrefs.GetInt("Best Score", finalScore);
        foreach (VehiclesBluePrint vehicle in vehicles)
        {
            nameofCar.text = " "+ vehicle.name;

            if (vehicle.name == "Vehicle1")

            {
                vehicle.isUnlocked = true;
            }
            else
            {
                vehicle.isUnlocked = PlayerPrefs.GetInt(vehicle.name, 0) == 0 ? false : true;
            }


            
        }
        currentIndex = PlayerPrefs.GetInt("currentIndex", 0);

        foreach (GameObject vehicle in vehicleModels)
            vehicle.SetActive(false);
        vehicleModels[currentIndex].SetActive(true);

    }
    private void Update()
    {
        UpdateUI();
        
         
    }

    public void ChangeNext()
    {

        vehicleModels[currentIndex].SetActive(false);
        currentIndex++;
        if (currentIndex == vehicleModels.Length)
            currentIndex = 0;

        vehicleModels[currentIndex].SetActive(true);

        VehiclesBluePrint vehicle = vehicles[currentIndex];
        if (!vehicle.isUnlocked)
            return;
        
        
        PlayerPrefs.SetInt("currentIndex", currentIndex);
    }
    public void ChangePrevious()
    {

        vehicleModels[currentIndex].SetActive(false);
        currentIndex--;
        if (currentIndex == -1)
            currentIndex = vehicleModels.Length - 1;

        vehicleModels[currentIndex].SetActive(true);

        VehiclesBluePrint vehicle = vehicles[currentIndex];
        if (!vehicle.isUnlocked)
            return;

        PlayerPrefs.SetInt("currentIndex", currentIndex);
    }
    public void UnlockCar()
    {
        VehiclesBluePrint vehicle = vehicles[currentIndex];
        PlayerPrefs.SetInt(vehicle.name, 2);

        PlayerPrefs.SetInt("currentIndex", currentIndex);
        vehicle.isUnlocked = true;

       
        
    }
    public void SelectedVehicles()
    {
        currentIndex = PlayerPrefs.GetInt("currentIndex");

        foreach (GameObject vehicle in vehicleModels)
            vehicle.SetActive(false);
        vehicleModels[currentIndex].SetActive(true);

        Debug.Log(vehicleModels[currentIndex] + "is selected");
       

    }


    public string popupText;

   [SerializeField] public int mainLevel;
    public void  UpdateUI()
    {
        VehiclesBluePrint vehicle = vehicles[currentIndex];
        int vehicleCoin = vehicle.price;
        //int coinMan = CoinManager.instance.initialCoins;
        
        string text = vehicle.name;
        nameofCar.text = " "+ text;
      //  Debug.Log(mainLevel);
        if (vehicle.isUnlocked)
        {
            // vehicleModels[currentIndex].SetActive(true);
            buyButton.gameObject.SetActive(false);
        }

        else
        {
            // vehicleModels[currentIndex].SetActive(false);
            buyButton.gameObject.SetActive(true);
            buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Get a distance of " + vehicle.price;
            /*if (vehicle.level <= mainLevel)
            {
                if (vehicleCoin < 50)
                {
                    buyButton.interactable = true;

                }
                else
                {
                    buyButton.interactable = false;
                    Debug.Log("No money");
                }
            }*/

            /*else

            {
                buyButton.interactable = false;
                Debug.Log("it is not working");
            }*/

            if (vehicleCoin < finalScore)
            {
                buyButton.interactable = true;

            }
            else
            {
                buyButton.interactable = false;
                Debug.Log("No money");
            }
        }
    }

   public string getName()
    {
        return vehicles[PlayerPrefs.GetInt("currentIndex", 0)].name;
    }
}
