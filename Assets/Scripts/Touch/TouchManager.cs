using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    public delegate void touchDelegate(Vector2 position);

    public event touchDelegate touchStartEvent;
    public event touchDelegate touchStopEvent;
    public event touchDelegate touchUpdateEvent;

    TouchControls touchControls;
    bool violated = false;

    static TouchManager instance;
    static public TouchManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<TouchManager>();
            }
            return instance;
        }
    }

    public Vector2 position { get => touchControls.Touch.TouchPosition.ReadValue<Vector2>(); }

    private void Awake()
    {
        instance = this;
        touchControls = new TouchControls();
    }

    private void OnEnable()
    {
        touchControls.Enable();
    }

    private void OnDisable()
    {
        touchControls.Disable();
    }

    void Start()
    {
        touchControls.Touch.TouchPress.started += TouchPress_Started;
        touchControls.Touch.TouchPress.canceled += TouchPress_Canceled;
    }

    private void TouchPress_Started(InputAction.CallbackContext context)
    {
        Debug.Log("you have violated me");
        touchStartEvent?.Invoke(position);
        violated = true;
    }

    private void TouchPress_Canceled(InputAction.CallbackContext context)
    {
        Debug.Log("you stopped, thank god");
        touchStopEvent?.Invoke(position);
        violated = false;
    }

    void Update()
    {
        if (violated)
        {
            touchUpdateEvent?.Invoke(position);
        }
    }
}
