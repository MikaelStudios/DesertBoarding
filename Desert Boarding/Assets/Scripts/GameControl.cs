using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public int currentIndex;
    public GameObject[] vehicleModels;
    CharacterSelector manager;
    // Start is called before the first frame update
    void Start()
    {
        currentIndex = PlayerPrefs.GetInt("currentIndex", 0);
        foreach (GameObject vehicle in vehicleModels)
            vehicle.SetActive(false);
        vehicleModels[currentIndex].SetActive(true);
        //playerObject =Instantiate(vehicles[currentIndex],playerStartPosition.position,vehicles[currentIndex].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
