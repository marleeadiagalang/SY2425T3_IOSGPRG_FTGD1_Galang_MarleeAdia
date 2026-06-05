using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public TouchInput.SwipeDirection requiredDirection;

    [SerializeField] private int _health;
    [SerializeField] private int _speed;

 

    public void Initialize()
    {
        _health = Random.Range(1, 100);
        _speed = Random.Range(1, 10);

        requiredDirection = (TouchInput.SwipeDirection)Random.Range(0, 4);
          
    }


    public void Kill()
    {
        Spawner.Instance.RemoveEnemyFromList(this);

        Debug.Log("Enemy Killd");

        Destroy(gameObject);
    }
}
