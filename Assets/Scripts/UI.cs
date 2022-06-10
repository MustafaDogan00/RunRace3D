using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public static UI Instance;

    public GameObject inGame, levelPanel,levelRPanel;

    public Text timerText;

    public Text currentLevelText;
    public Text nextLevelText;


    void Awake()
    {
        Instance = this;
        StartCoroutine(Timer());
    }
    
    public IEnumerator Timer()
    {
        timerText.gameObject.SetActive(true);
        timerText.text = 3.ToString();
        yield return new WaitForSeconds(1);
        timerText.text = 2.ToString();
        timerText.color = Color.magenta;
        yield return new WaitForSeconds(1);
        timerText.text = 1.ToString();
        timerText.color = Color.green;
        yield return new WaitForSeconds(1);
        timerText.text = "Go";
        timerText.color = Color.cyan;
        yield return new WaitForSeconds(.5f);
        timerText.gameObject.SetActive(false);
        GameManager.Instance.start = true;


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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevelButton()
    { 
    
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        currentLevelText.text = (SceneManager.GetActiveScene().buildIndex + 1).ToString();
        nextLevelText.text = (SceneManager.GetActiveScene().buildIndex + 2).ToString();

    }
    public void ExitButton()
    {
        SceneManager.LoadScene(0);
    }


}
