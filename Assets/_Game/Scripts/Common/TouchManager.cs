using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class TouchManager : MonoBehaviour
{
    private PlayerInput playerInput;

    private InputAction touchPositionAction;
    private InputAction touchPressAction;

    public UnityEvent OnTap;

    public bool IsTapPressed { get; private set; }
    public int _numberOfTaps {  get; private set; }

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchPositionAction = playerInput.actions["TouchPosition"];
        touchPressAction = playerInput.actions["TouchPress"];
    }

    private void OnEnable()
    {
        touchPressAction.performed += TouchPressed;
    }

    private void OnDisable()
    {
        touchPressAction.performed -= TouchPressed;
        IsTapPressed = false;
    }

    private void TouchPressed(InputAction.CallbackContext context)
    {
        IsTapPressed = true;
        _numberOfTaps++;
        //Debug.Log("Number of Taps: " + _numberOfTaps);
    }

    public void Tap()
    {
        OnTap?.Invoke();

    }
}
