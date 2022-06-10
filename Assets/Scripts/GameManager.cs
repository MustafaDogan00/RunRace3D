using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 

    private GameObject[] runners;
    public GameObject crown;

    public int pass;

    public string firstPlace, secondPlace,thirdPlace;

    public bool finish,start;

    List<Ranking> sortList=new List<Ranking>();

    private InGameUI _rankingScript;

    private void Awake()
    {
        Instance = this;
        runners = GameObject.FindGameObjectsWithTag("Runners");
        _rankingScript=GetComponent<InGameUI>();
       
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
        switch(sortList.Count)
        {
            case 3:
                sortList[0].rank = 3;
                sortList[1].rank = 2;
                sortList[2].rank = 1;

                _rankingScript.a = sortList[2].name;
                _rankingScript.b= sortList[1].name;
                _rankingScript.c= sortList[0].name;
                crown.gameObject.transform.SetParent(sortList[2].gameObject.transform);

                break;
            case 2:
                sortList[0].rank = 2;
                sortList[1].rank = 1;

                _rankingScript.a=sortList[1].name;
                _rankingScript.b=sortList[0].name;
                _rankingScript.myImage.color=Color.red;
                crown.gameObject.transform.SetParent(sortList[1].gameObject.transform);


                break;
            case 1:
                sortList[0].rank = 1;
              
                _rankingScript.a = sortList[0].name;
                crown.gameObject.transform.SetParent(sortList[0].gameObject.transform);
                if (sortList[0].name=="Player")
                {
                    UI.Instance.NextLevel();
                }
               
                if (firstPlace=="")
                {
                    firstPlace = sortList[0].name;
                }
                break;


        }

        if (pass >= ((float)runners.Length)/2)
        { 
            pass = 0;
            sortList = sortList.OrderBy(x => x.counter).ToList();

            foreach (Ranking rs in sortList)
            {

                if (rs.rank == sortList.Count)
                {
                    print(rs.gameObject.name);
                    if (rs.gameObject.name=="Player")
                    {
                        UI.Instance.Reload();                   
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
