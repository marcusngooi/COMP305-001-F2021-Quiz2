using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    public float scrollSpeed = 0.5f;

    private Renderer renderer; // Use base type because it will work for all Renderer types

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        InvokeRepeating("MoveBG", scrollSpeed, scrollSpeed);
    }

    private void MoveBG()
    {
        renderer.material.mainTextureOffset = new Vector2(renderer.material.mainTextureOffset.x + 0.05f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // smooth
        // renderer.material.mainTextureOffset = new Vector2(Time.time * scrollSpeed, 0);
    }
}
