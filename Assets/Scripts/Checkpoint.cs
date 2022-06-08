using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [HideInInspector]
    public GameObject[] checkPoints;

    [HideInInspector]
    public int currentCheckpoint=1;
    void Awake()
    {
        checkPoints = GameObject.FindGameObjectsWithTag("CheckPoint");
        currentCheckpoint = 1;
    }


    private void Start()
    {
        foreach  (GameObject cp in checkPoints)
        {
            cp.AddComponent<CurrentCheckPoint1>();
            cp.GetComponent<CurrentCheckPoint1>().currentCheckNumber = currentCheckpoint;
            cp.name = "Checkpoint" + currentCheckpoint;
            currentCheckpoint++;
            
        }
    }
}
