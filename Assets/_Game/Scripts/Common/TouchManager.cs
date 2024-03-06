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
    public UnityEvent TapDuringGameplay;

    public bool AreWeInGamePlayState;

    public bool IsTapPressed { get; private set; }

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
        IsTapPressed = false;

        touchPressAction.performed -= TouchPressed;
    }

    private void TouchPressed(InputAction.CallbackContext context)
    {
        IsTapPressed = true;

        if (!AreWeInGamePlayState)
        {
            OnTap?.Invoke();
        }
        else
        {
            TapDuringGameplay?.Invoke();
        }
    }
}
