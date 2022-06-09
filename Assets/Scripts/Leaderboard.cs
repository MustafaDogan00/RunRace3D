using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public Text[] texts;

    void Update()
    {
        texts[0].text = GameManager.Instance.firstPlace;
        texts[1].text = GameManager.Instance.secondPlace;
        texts[2].text = GameManager.Instance.thirdPlace;
    }
}
