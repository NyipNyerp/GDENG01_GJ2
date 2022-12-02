using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTargetting : MonoBehaviour
{
    List<GameObject> targets = new List<GameObject>();
    public GameObject target;
    float distance = 100;
    // Update is called once per frame
    void Update()
    {
        if (targets.Count > 0)
        {
            for (int i = 0; i < targets.Count; i++)
            {
                float tempDistance = GetDistance(targets[i]);
                //Debug.Log(targets[i].name + " TempDistance = " + tempDistance);
                //Debug.Log(targets[i].name + " Distance = " + distance);
                if (tempDistance < distance)
                {
                    target = ChangeTarget(targets[i]);
                }
                distance = tempDistance;
            }
        }
        else
        {
            target = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "FPSPlayer" || other.name == "CivilianAsian")
        {
            Debug.Log("Spotted: " + other.gameObject.name);
            targets.Add(other.gameObject);
        }
    }

    /*
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "FPSPlayer" || other.name == "CivilianAsian")
        {
        targets.Remove(other.gameObject);
        }
    }
    */

    private float GetDistance(GameObject gameObject)
    {
        float dist = Vector3.Distance(this.transform.position, gameObject.transform.position);

        return dist;
    }

    private GameObject ChangeTarget(GameObject target)
    {
        Debug.Log("Targeting: " + target.name);
        return target;
    }
}
