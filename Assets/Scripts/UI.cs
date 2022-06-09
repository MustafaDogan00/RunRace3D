using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public static UI Instance;
    public GameObject inGame, levelPanel,levelRPanel;

    void Awake()
    {
        Instance = this;
        
    }

    public void Reload()
    {
      inGame.SetActive(false);
        levelRPanel.SetActive(true);

    }
    public void NextLevel()
    {
        inGame.SetActive(false);
        levelPanel.SetActive(true);
    }

     public void ReloadButton()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevelButton()
    { 
    
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    
    }


}
