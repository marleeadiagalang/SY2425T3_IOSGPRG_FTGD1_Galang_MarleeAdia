using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private bool _detectedByPlayer = false;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private List<Sprite> _arrowSprites = new List<Sprite>();
    


    private void Start()
    {
        StartCoroutine(CO_ArrowRotation());
        StartCoroutine(C0_SpawnEnemyEveryXSeconds(5));
    }

    private IEnumerator CO_ArrowRotation()
    {

        int index = 0;

        while (!_detectedByPlayer)
        {

            yield return new WaitForSeconds(1);
            _spriteRenderer.sprite = _arrowSprites[index % 4]; 
            index++;
        }

    }

    private IEnumerator C0_SpawnEnemyEveryXSeconds(float seconds)
    {
        float currentTime = 0f;

        while (true)
        {
            currentTime += Time.deltaTime;
            // Debug.Log($"Spawn timer: {currentTime}");
            if (currentTime >= seconds)
            {
                Spawner.Instance.SpawnEnemy();
                currentTime = 0f;
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
