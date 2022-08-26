using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FueRemove : MonoBehaviour
{
    public Slider mana1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mana1.value -= 100;
 
 
 
        if (Input.GetKeyDown("b"))
        {
            mana1.value += 20;
            
 
 
        }
 
        
    }
}
