using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantPlatform : MonoBehaviour
{
    [Range(-1f, 5f)]
    public float scrollSpeed = 0.5f;

    private float offset;
    private Material mat; 

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material; 

    }

    // Update is called once per frame
    void Update()
    {
        offset += (scrollSpeed * Time.deltaTime) / 10;
        mat.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}
