using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongPressed : MonoBehaviour
{
    
    public bool rightButtonDown, rightButtonUp;
    public bool leftButtonDown, leftButtonUp;
    public bool brakeButtonUp , brakeButtonDown;
    public bool accelerateButtonDown, accelerateButtonUp;

    public bool breakDown, breakUp;


    public Button rightButton, leftButton, breakButton, accelerateButton;
    
    public static LongPressed instance;
    
    public void Awake()
    {
        instance = this;
    }
    
    private void Start(){
        SetupButtonControlEvents();
    }

    private void SetupButtonControlEvents()
    {
        // Right Button Events
        var rightPointerDown = new  EventTrigger.Entry();
        rightPointerDown.eventID = EventTriggerType.PointerDown;
        rightPointerDown.callback.AddListener((e) => RightButtonPointerCallback(true));

        var rightPointerUp = new  EventTrigger.Entry();
        rightPointerUp.eventID = EventTriggerType.PointerUp;
        rightPointerUp.callback.AddListener((e) => RightButtonPointerCallback(false));


        EventTrigger rightTrigger = rightButton.gameObject.AddComponent<EventTrigger>();
        rightTrigger.triggers.Add(rightPointerDown);
        rightTrigger.triggers.Add(rightPointerUp);


        // Left Button Events
        var leftPointerDown = new  EventTrigger.Entry();
        leftPointerDown.eventID = EventTriggerType.PointerDown;
        leftPointerDown.callback.AddListener((e) => LeftButtonPointerCallback(true));

        var leftPointerUp = new  EventTrigger.Entry();
        leftPointerUp.eventID = EventTriggerType.PointerUp;
        leftPointerUp.callback.AddListener((e) => LeftButtonPointerCallback(false));

        EventTrigger leftTrigger = leftButton.gameObject.AddComponent<EventTrigger>();
        leftTrigger.triggers.Add(leftPointerDown);
        leftTrigger.triggers.Add(leftPointerUp);

        //Brake Button Events
        var brakeButtonUp = new EventTrigger.Entry();
        brakeButtonUp.eventID = EventTriggerType.PointerDown;
        brakeButtonUp.callback.AddListener((e) => BrakeButtonPointerCallback(true));

        var brakeButtonDown = new  EventTrigger.Entry();
        brakeButtonDown.eventID = EventTriggerType.PointerUp;
        brakeButtonDown.callback.AddListener((e) => BrakeButtonPointerCallback(false));

        EventTrigger brakeTrigger = breakButton.gameObject.AddComponent<EventTrigger>();
        brakeTrigger.triggers.Add(brakeButtonDown);
        brakeTrigger.triggers.Add(brakeButtonUp);

        // Accelerate Button Events
        var acceleratePointerDown = new  EventTrigger.Entry();
        acceleratePointerDown.eventID = EventTriggerType.PointerDown;
        acceleratePointerDown.callback.AddListener((e) => AccelerateButtonPointerCallback(true));

        var acceleratePointerUp = new  EventTrigger.Entry();
        acceleratePointerUp.eventID = EventTriggerType.PointerUp;
        acceleratePointerUp.callback.AddListener((e) => AccelerateButtonPointerCallback(false));

        EventTrigger accelerateTrigger = accelerateButton.gameObject.AddComponent<EventTrigger>();
        accelerateTrigger.triggers.Add(acceleratePointerDown);
        accelerateTrigger.triggers.Add(acceleratePointerUp);



    }

    public void RightButtonPointerCallback(bool state)
    {
        rightButtonDown = state;
    }
    
    public void LeftButtonPointerCallback(bool state)
    {
        leftButtonDown = state;
    }
    public void BrakeButtonPointerCallback(bool state)
    {
        brakeButtonDown = state;
    } 
    public void AccelerateButtonPointerCallback(bool state)
    {
        accelerateButtonDown = state;
    }
           
}