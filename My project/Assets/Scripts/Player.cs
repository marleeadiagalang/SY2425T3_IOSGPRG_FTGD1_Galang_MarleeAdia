using UnityEngine;
using System.Collections.Generic; 

public class Player : MonoBehaviour
{
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
