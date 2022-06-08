using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    private GameObject[] runners;

    List<Ranking> sortList=new List<Ranking>();

    private void Awake()
    {
        runners = GameObject.FindGameObjectsWithTag("Runners");
    }
    void Start()
    {

        for(int i=0;i<runners.Length;i++)
        {
            sortList.Add(runners[i].GetComponent<Ranking>());
                
        }
        
    }

    
    void Update()
    {
        CalculatingRank();
    }

    void CalculatingRank()
    {
        sortList=sortList.OrderBy(x => x.counter).ToList();
        sortList[0].rank = 3;
        sortList[1].rank = 2;
        sortList[2].rank = 1;
       

    }
}
