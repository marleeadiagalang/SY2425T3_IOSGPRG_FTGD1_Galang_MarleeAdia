using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializedField] public TouchInput.InputState RequiredDirection;

    private bool isActive = false;


    private void OnEnable()
    {
        TouchInput.OnSwipeDetected += CheckPlayerInput;
        SetRandomDirection();
    }

    private void OnDisable()
    {
        TouchInput.OnSwipeDetected -= CheckPlayerInput;
    }

    public void SetRandomDirection()
    {
        RequiredDirection = (TouchInput.InputState)Random.Range(1, 5);
        Debug.Log("Enemy spawned with direction: " + RequiredDirection);
    }

    private void CheckPlayerInput(TouchInput.InputState inputState)
    {
        if (inputState == RequiredDirection)
        {
            Spawner.Instance.RemoveEnemyFromList(this);
            Destroy(gameObject);
            Debug.Log("Destroyed");
        }
    }


    [SerializeField] private int _health;
    [SerializeField] private int _speed;




    public void Initialize()
    {
        _health = Random.Range(1, 100);
        _speed = Random.Range(1, 10);
    }
}
