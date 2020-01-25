//Zachary Brennan 1/24/2020

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    //Variables
    public Text winText;
    public Text timerText;

    // Update is called once per frame

    private void Update()
    {
        WinCondition(); //Checks for win condition
    }
    void WinCondition()
    {
        //If false changes text
        if(GlobalVariables.winCondition == false)
        {
            winText.text = "You died!";
            timerText.text = "";
        }
        else//if true changes text
        {
            
            winText.text = "You won!";
            timerText.text = "Timer: " + (int)GlobalVariables.timeEnd + " seconds";
        }
    }
}
