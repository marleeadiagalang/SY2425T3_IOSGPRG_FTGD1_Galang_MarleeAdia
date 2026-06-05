
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class TouchInput : MonoBehaviour
{
    public enum SwipeDirection
    {
        Up,
        Right,
        Down,
        Left
        
    }
    [SerializeField] private PlayerInput _playerInput;

    private InputAction _touchPressedAction;
    private InputAction _touchPositionAction;

    private Vector2 _touchStart;
    private Vector2 _touchEnd;

    private void Awake()
    {
        if (_playerInput == null)
        {
            Debug.LogError("PlayerInput is not assigned to TouchInput");
            return;
        }
        _touchPressedAction = _playerInput.actions["TouchPress"];
        _touchPositionAction = _playerInput.actions["TouchPosition"];
    }

    private void OnEnable()
    {
        _touchPressedAction.started += OnTouchStarted;
        _touchPressedAction.canceled += OnTouchReleased;
    }

    private void OnDisable()
    {
        if (_touchPressedAction != null)
        {
            _touchPressedAction.started -= OnTouchStarted;
            _touchPressedAction.canceled -= OnTouchReleased;
        }
       
        
    }

    private void OnTouchStarted(InputAction.CallbackContext context)
    {
        _touchStart = _touchPositionAction.ReadValue<Vector2>();
    }


    private void OnTouchReleased(InputAction.CallbackContext context)
    {
        _touchEnd = _touchPositionAction.ReadValue<Vector2>();

        SwipeDirection direction = GetSwipeDirection();

        Debug.Log($"Player Swiped {direction}");

        CheckEnemy(direction);
    }

    private SwipeDirection GetSwipeDirection()
    {
        Vector2 swipe = _touchEnd - _touchStart;

        if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
        {
            return swipe.x > 0 ? SwipeDirection.Right : SwipeDirection.Left;
        }

        return swipe.y > 0 ? SwipeDirection.Up : SwipeDirection.Down;
    }

    private void CheckEnemy(SwipeDirection playerSwipe)
    {
        Enemy enemy = Spawner.Instance.GetFrontEnemy();

        if (enemy == null)
        {
            return;
        }

        if (enemy.requiredDirection == playerSwipe)
        {
            enemy.Kill();
            Debug.Log("Enemy Killed");
        }
        else
        {
            Debug.Log("Wrong Swipe");
        }
    }

}
