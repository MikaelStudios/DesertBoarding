using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AngleTurned : MonoBehaviour
{
        //Use these to get the GameObject's positions
    Vector2 m_MyFirstVector;
    Vector2 m_MySecondVector;

    public TextMeshProUGUI angleText;

    float m_Angle;

    //You must assign to these two GameObjects in the Inspector
    public GameObject m_MyObject;
    public GameObject m_MyOtherObject;
    int number_of_flips = 0;

    void Start()
    {
        //Initialise the Vector
        m_MyFirstVector = Vector2.zero;
        m_MySecondVector = Vector2.zero;
        m_Angle = 0.0f;
    }

    void Update()
    {
        if(!PlayerMovement.instance.isGrounded)
        {
            //Fetch the first GameObject's position
            m_MyFirstVector = new Vector2(m_MyObject.transform.position.x, m_MyObject.transform.position.y);
            //Fetch the second GameObject's position
            m_MySecondVector = new Vector2(m_MyOtherObject.transform.position.x, m_MyOtherObject.transform.position.y);
            //Find the angle for the two Vectors
            m_Angle = Vector2.Angle(m_MyFirstVector, m_MySecondVector);

            
            //Log values of Vectors and angle in Console
           /* Debug.Log("MyFirstVector: " + m_MyFirstVector);
            Debug.Log("MySecondVector: "  + m_MySecondVector);
            Debug.Log("Angle Between Objects: " + m_Angle);
            

            */
            int angle =(int)m_Angle;
            if(angle == 170)
            {
                number_of_flips ++;
                angleText.text = "Angle: " + number_of_flips;  
            }
            /*if(angle % 45 == 0 && angle != 0)
            {
                angleText.text = "Angle: " + number_of_flips;  
                number_of_flips ++;
                Debug.Log("angle: " + angle);
            }*/
        }
    }

    void OnGUI()
    {
        //Output the angle found above
        GUI.Label(new Rect(25, 25, 200, 40), "Angle Between Objects" + m_Angle);
    }
}
 