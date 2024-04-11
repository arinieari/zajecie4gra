using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class flashlight : MonoBehaviour
{
    private Light2D light;
    private bool isDark;
    void Start()
    {
        light = GetComponent<Light2D>();
        light.enabled = false;
        isDark = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("dark"))
        {
            light.enabled = true;
            isDark = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isDark && collision.gameObject.CompareTag("dark"))
        {
            light.enabled = false;
            isDark = false;
        }
    }
}