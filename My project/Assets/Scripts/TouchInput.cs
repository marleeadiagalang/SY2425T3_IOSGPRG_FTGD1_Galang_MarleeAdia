
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class TouchInput : MonoBehaviour
{
    public enum InputState
    {
        None,
        Up,
        Right,
        Down,
        Left
        
    }

    public static event Action<InputState> OnSwipeDetected;

    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _swipeThreshold = 50f;

    private InputAction _touchPressedAction;
    private InputAction _touchPositionAction;

    private Vector2 _touchStart;
    private Vector2 _touchEnd;

    private void Awake()
    {
        _touchPressedAction = _playerInput.actions["TouchPress"];
        _touchPositionAction = _playerInput.actions["TouchPosition"];
    }

    private void OnEnable()
    {
        _touchPressedAction.started += OnTouchStarted;
        _touchPressedAction.canceled += OnTouchReleased;
        Debug.Log("Touch input enabled.");
    }


    private void OnDisable()
    {
        _touchPressedAction.started -= OnTouchStarted;
        _touchPressedAction.canceled -= OnTouchReleased;
        Debug.Log("Touch input disabled.");
    }

    private void OnTouchStarted(InputAction.CallbackContext context)
    {
        _touchStart = _touchPositionAction.ReadValue<Vector2>();
        
    }

    private void OnTouchReleased(InputAction.CallbackContext context)
    {
        _touchEnd = _touchPositionAction.ReadValue<Vector2>();
        
        if (_touchEnd.x < _touchStart.x)
        {
            Debug.Log("Swiped left");
        }
        else if (_touchEnd.x > _touchStart.x)
        {
            Debug.Log("Swiped right");
        }
    }
}
