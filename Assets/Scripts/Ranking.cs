using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    public int lapCount, currentCheckp=1,rank;

    private Vector3 _checkPoint;

    public float distance, counter;
   
    void Start()
    {
        currentCheckp = 1;
        _checkPoint = GameObject.Find("Checkpoint" + currentCheckp).transform.position;
    }

  
    void Update()
    {
        CalculateDistance();
    }

    void CalculateDistance()
    {
        distance=Vector3.Distance(transform.position,_checkPoint);
        counter = lapCount * 1000 + currentCheckp * 100 + distance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="CheckPoint")
        {
            currentCheckp = other.GetComponent<CurrentCheckPoint1>().currentCheckNumber;
            _checkPoint=GameObject.Find("Checkpoint"+ currentCheckp).transform.position;
        }
        if (other.tag == "Finish") 
        {
            lapCount++;
            currentCheckp = 1;
        }
    }
}
