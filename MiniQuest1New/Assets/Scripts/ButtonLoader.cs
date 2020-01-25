//Zachary Brennan 1/24/2020

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLoader : MonoBehaviour {
    //Variables
    public int sceneNumber;

    //Loads a scene based on the button's input
    public void Loader()
    {
        SceneManager.LoadScene(sceneNumber);
    }
    //Quits the game based on button input, Only happens with executable
    public void QuitGame()
    {
        Application.Quit();
    } 
}
