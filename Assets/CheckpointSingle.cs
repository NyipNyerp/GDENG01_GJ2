using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSingle : MonoBehaviour
{
    private MapCheckpoints mapCheckpoints;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            mapCheckpoints.PlayerThroughCheckpoint(this);
        }
    }
    public void SetMapCheckpoints(MapCheckpoints mapCheckpoints)
    {
        this.mapCheckpoints = mapCheckpoints;
    }
}
