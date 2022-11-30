using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCheckpoints : MonoBehaviour
{
    private List<CheckpointSingle> checkpointSingleList;
    private int nextCheckpointSingleIndex;
    private void Awake()
    {
        Transform checkpointsTransform = transform.Find("Checkpoints");
        checkpointSingleList = new List<CheckpointSingle>();

        foreach(Transform checkpointsSingleTransform in checkpointsTransform)
        {
            CheckpointSingle checkpointSingle = checkpointsSingleTransform.GetComponent<CheckpointSingle>();
            checkpointSingle.SetMapCheckpoints(this);
            checkpointSingleList.Add(checkpointSingle);
        }
        nextCheckpointSingleIndex = 0;
    }
    private void Update()
    {
        if(nextCheckpointSingleIndex == checkpointSingleList.Count)
        {
            //win
        }
        else
        {
            //lose
        }
    }

    public void PlayerThroughCheckpoint(CheckpointSingle checkpointSingle)
    {
       if(checkpointSingleList.IndexOf(checkpointSingle) == nextCheckpointSingleIndex)
        {
            //Correct Checkpoint
            Debug.Log("Correct");
        nextCheckpointSingleIndex = (nextCheckpointSingleIndex + 1) % checkpointSingleList.Count;
        }
        else
        {
            // Wrong Checkpoint
            Debug.Log("Wrong");
        }
    }
}
