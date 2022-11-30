using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VicinityLights : MonoBehaviour
{
    private Light _light;

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Spot Light")
        {
            collision.gameObject.TryGetComponent(out _light);
            _light.enabled = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Spot Light")
        {
            collision.gameObject.TryGetComponent(out _light);
            _light.enabled = false;
        }
    }
}
