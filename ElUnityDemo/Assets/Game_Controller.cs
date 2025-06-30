using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Controller : MonoBehaviour
{
    public Text readyText;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void DisplayReady()
    {
        readyText.text = "Ready!";
    }

    public void ClearReadyText()
    {
        readyText.text = " ";
    }
}
