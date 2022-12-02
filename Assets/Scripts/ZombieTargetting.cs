using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTargetting : MonoBehaviour
{
    List<GameObject> targets = new List<GameObject>();
    [SerializeField] private GameObject target;
    float distance = 100;
    // Update is called once per frame
    void Update()
    {
        if (targets.Count > 0 )
        {
            Debug.Log(this.gameObject.name + " has " + targets.Count + " targets");
            for (int i = 0; i < targets.Count; i++)
            {
                if (targets[i].tag == "Civilian")
                {
                    CivilianNavigation civilian;
                    targets[i].TryGetComponent(out civilian);

                    if (!civilian.CheckAlive())
                    {
                        Debug.Log(targets[i].name + " has died!!");
                        targets.Remove(targets[i]);
                        continue;
                    }
                }

                float tempDistance = GetDistance(targets[i]);
                if (tempDistance < distance && target != null)
                {
                    target = targets[i];
                    distance = tempDistance;
                }
                else
                {
                    target = targets[i];
                }
            }
        }
        else
        {
            target = null;
            distance = 100;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Civilian")
        {
            if (!targets.Contains(other.gameObject))
            {
                //Debug.Log("Spotted: " + other.gameObject.name);
                targets.Add(other.gameObject);
            }
        }
    }

    /*
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "FPSPlayer" || other.name == "Civilian")
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

    public GameObject GetTarget()
    {
        //Debug.Log(this.gameObject.name + " Targeting: " + target.name);
        return target;
    }
}
