using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalCamera : MonoBehaviour
{
    public float scrollSpeed = 5f;

    void update()
    {
        transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
    }
}
