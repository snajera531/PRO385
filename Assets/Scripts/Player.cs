using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10;
    public GameObject shot;
    Vector2 input;

    void Start()
    {
        GetComponent<PlayerInput>().onActionTriggered += HandleAction;
    }

    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        transform.Translate(input * speed * Time.deltaTime);

        if (Input.GetButtonDown("Fire1"))
        {
            OnFire();
        }

        Gamepad gamepad = Gamepad.current;
        if (gamepad == null) return;
        input = gamepad.leftStick.ReadValue();

        if (gamepad.buttonSouth.wasPressedThisFrame)
        {
            OnFire();
        }
    }

    public void OnFire()
    {
        Instantiate(shot, transform.position, Quaternion.identity);
    }

    public void OnMove(InputValue inputValue)
    {
        input = inputValue.Get<Vector2>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
    }

    private void HandleAction(InputAction.CallbackContext context)
    {
        if(context.action.name == "Fire")
        {
            OnFire();
        }

        if(context.action.name == "Move")
        {
            OnMove(context);
        }
    }
}
