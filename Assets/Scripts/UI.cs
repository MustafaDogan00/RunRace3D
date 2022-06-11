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
    public Text[] texts;

    public Image fill,fillR;

    public Sprite orange, gray;
  


    void Awake()
    {
        Instance = this;
        StartCoroutine(Timer());
     

    }
    private void Start()
    {
        levelPanel.SetActive(false);
        levelRPanel.SetActive(false);
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

   
    public void LevelPanel()
    {
        inGame.SetActive(false);
        levelPanel.SetActive(true);
        texts[0].text = PlayerPrefs.GetInt("Level", 1)-1+"";
        texts[1].text = PlayerPrefs.GetInt("Level", 1).ToString();
        fill.sprite = orange;
    }
    public void LevelRPanel()
    {
        inGame.SetActive(false);
        levelRPanel.SetActive(true);
        texts[2].text = PlayerPrefs.GetInt("Level", 1).ToString();
        texts[3].text = PlayerPrefs.GetInt("Level", 1) + 1 + "";
        fillR.sprite = gray;

    }

  
    public void ReloadButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        levelRPanel.SetActive(false);

    }

    public void NextLevelButton()
    {
        levelPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void ExitButton()
    {
        SceneManager.LoadScene(0);
    }


}
