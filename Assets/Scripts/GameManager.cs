using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 

    private GameObject[] runners;

    public int pass;

    public string firstPlace, secondPlace,thirdPlace;

    public bool finish;

    List<Ranking> sortList=new List<Ranking>();
   

    private void Awake()
    {
        Instance = this;
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
        Debug.Log(pass);
        sortList=sortList.OrderBy(x => x.counter).ToList();
        switch(sortList.Count)
        {
            case 3:
                sortList[0].rank = 3;
                sortList[1].rank = 2;
                sortList[2].rank = 1;
                break;
            case 2:
                sortList[0].rank = 2;
                sortList[1].rank = 1;
                break;
            case 1:
                sortList[0].rank = 1;
                if (firstPlace=="")
                {
                    firstPlace = sortList[0].name;
                }
                break;


        }
     
        if (pass >= ((float)runners.Length+4)/2 )
        {
            pass = 0;
            sortList = sortList.OrderBy(x => x.counter).ToList();

            foreach (Ranking rs in sortList)
            {

                if (rs.rank == sortList.Count)
                {
                    if (rs.gameObject.name=="Player")
                    {
                        //
                    }
                    if (thirdPlace == "")
                        thirdPlace = rs.gameObject.name;
                    else if(secondPlace =="")
                        secondPlace = rs.gameObject.name;

                     rs.gameObject.SetActive(false);
                }
            }
            runners = GameObject.FindGameObjectsWithTag("Runners");
            sortList.Clear();
            for (int i = 0; i < runners.Length; i++)
            {
                sortList.Add(runners[i].GetComponent<Ranking>());

            }

            if (runners.Length<2)
            {
                finish = true;
            }

        }

    }
}
