using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongPressed : MonoBehaviour
{
    
    public bool rightButtonDown, rightButtonUp;
    public bool leftButtonDown, leftButtonUp;

    public Button rightButton, leftButton;
    
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

    }

    public void RightButtonPointerCallback(bool state)
    {
        rightButtonDown = state;
    }
    
    public void LeftButtonPointerCallback(bool state)
    {
        leftButtonDown = state;
    }
        
           
}