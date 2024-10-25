using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Color color = spriteRenderer.color;
            color.a = 0.7f; 
            spriteRenderer.color = color;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Color color = spriteRenderer.color;
            color.a = 1f; 
            spriteRenderer.color = color;
        }
    }

}