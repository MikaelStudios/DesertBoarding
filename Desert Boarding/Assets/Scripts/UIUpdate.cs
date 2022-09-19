using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIUpdate : MonoBehaviour
{
    public TextMeshProUGUI myName;
    public TextMeshProUGUI enterName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Submit()
    {
        enterName.text = " " + myName.text;
    }
}
