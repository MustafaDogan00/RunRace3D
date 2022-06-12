using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public InputField inputField;

    public Text currentLevelText;
    public Text nextLevelText;

    private Animator _animator;


    private void Awake()
    {
      /*  _animator = GameObject.FindGameObjectWithTag("Image").GetComponent<Animator>();
        _animator.SetTrigger("Flash2");*/
        
    }
    void Start()
    {
        currentLevelText.text = PlayerPrefs.GetInt("Level", 1).ToString();
        nextLevelText.text = PlayerPrefs.GetInt("Level", 1) + 1 + "";
        if (PlayerPrefs.GetInt("FirstTime",0)==0)
        {
            PlayerPrefs.SetInt("FirstTime", 1);
        }
        else
        {
            PlayerPrefs.GetString("PlayerName");
        }
    }
    public void StartGame()
    {
        if (inputField.text == "")
            PlayerPrefs.SetString("PlayerName", "Player");
       else
            PlayerPrefs.SetString("PlayerName", inputField.text);

        SceneManager.LoadScene(PlayerPrefs.GetInt("Level",2));

    }
   
  public void ChangeColor()
    {
        SceneManager.LoadScene(1);


    }
}
