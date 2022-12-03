using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCheckpoints : MonoBehaviour
{
    public static MapCheckpoints instance;
    private List<CheckpointSingle> checkpointSingleList;
    private int nextCheckpointSingleIndex;
    [SerializeField] private GameObject winPanel;
    private bool isLose = false;
    private void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;

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
        
        if(nextCheckpointSingleIndex == checkpointSingleList.Count && !isLose)
        {
            //win
            Debug.Log("Win");
            winPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else if(isLose)
        {
            //lose
            //Debug.Log("Lose");
        }
    }

    public void PlayerThroughCheckpoint(CheckpointSingle checkpointSingle)
    {
       if(checkpointSingleList.IndexOf(checkpointSingle) == nextCheckpointSingleIndex)
        {
            //Correct Checkpoint
            Debug.Log("Correct");
            nextCheckpointSingleIndex++;
            //Debug.Log(nextCheckpointSingleIndex);
            //Debug.Log(checkpointSingleList.Count);
        }
        else
        {
            // Wrong Checkpoint
            Debug.Log("Wrong");
        }
    }

    public void isGameOver(bool IsLose)
    {
        isLose = IsLose;
    }
}
