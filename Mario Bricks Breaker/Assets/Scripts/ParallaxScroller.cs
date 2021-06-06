using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroller : MonoBehaviour
{
    public Camera cam;

    public GameObject[] layers;
    public float[] speedMultipliers;

    public float scrollSpeed;

    // Update is called once per frame
    void Update()
    {
        for (var idx = 0; idx < layers.Length; idx ++)
        {
            GameObject layer = layers[idx];
            layer.transform.Translate(Vector2.left * scrollSpeed * speedMultipliers[idx] * Time.deltaTime);
        }
    }
}
