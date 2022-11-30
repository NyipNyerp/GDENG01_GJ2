using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VicinityLights : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //CollidedTarget.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        //CollidedTarget.SetActive(false);
    }
}
