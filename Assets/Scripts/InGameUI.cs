using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public Text[] myText;

    public Image myImage;

    public string a,b,c;

    void Update()
    {
        myText[0].text = a;
        myText[1].text = b;
        myText[2].text = c;
      
    }
}
