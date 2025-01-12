using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //Starts the main game scene
    public void startGame ()
    {
        FindObjectOfType<AudioManager>().playSound("Button Click");

        SceneManager.LoadScene(1);
    }

    //Closes the game
    public void quit ()
    {
        FindObjectOfType<AudioManager>().playSound("Button Click");

        Application.Quit();
    }
}
