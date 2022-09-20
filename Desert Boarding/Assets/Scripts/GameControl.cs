using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public int currentIndex;
    public int currentCamerandex;
    public GameObject[] vehicleModels;
    CharacterSelector manager;
    public GameObject[] virtualCamera;
    // Start is called before the first frame update
    void Start()
    {
        
        currentIndex = PlayerPrefs.GetInt("currentIndex", 0);
        foreach (GameObject vehicle in vehicleModels)
            vehicle.SetActive(false);
        foreach(GameObject camera in virtualCamera)
        {
            camera.SetActive(false);
        }
        virtualCamera[currentIndex].SetActive(true);
        vehicleModels[currentIndex].SetActive(true);
        //playerObject =Instantiate(vehicles[currentIndex],playerStartPosition.position,vehicles[currentIndex].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
