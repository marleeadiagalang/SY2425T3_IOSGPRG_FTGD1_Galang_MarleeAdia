using UnityEngine;
using System.Collections.Generic; 

public class Player : MonoBehaviour
{
    //public float speed = 5f;

    //void Update()
    //{
    //    transform.Translate(Vector3.up * speed * Time.deltaTime);
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            Spawner.Instance.RemoveEnemyFromList(enemy);
            Destroy(enemy.gameObject);
        }
    }

}
