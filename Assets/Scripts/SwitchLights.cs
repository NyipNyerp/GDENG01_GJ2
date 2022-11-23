using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLights : MonoBehaviour
{
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    Light light;

    void Start()
    {
        light = GetComponent<Light>();
    }

    void Update()
    {
        light.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * 1, 1));
    }
}
