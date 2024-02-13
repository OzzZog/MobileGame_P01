using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class TouchManager : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private PlayerInput playerInput;

    private InputAction touchPositionAction;
    private InputAction touchPressAction;

    public UnityEvent OnTap;

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
        touchPressAction.performed -= TouchPressed;
        IsTapPressed = false;
    }

    private void TouchPressed(InputAction.CallbackContext context)
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(touchPositionAction.ReadValue<Vector2>());
        position.z = player.transform.position.z;
        player.transform.position = position;
        IsTapPressed = true;
    }

    public void Tap()
    {
        OnTap?.Invoke();

    }
}
