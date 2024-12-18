using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Function to begin gameplay
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        //LoadScene() loads the scene specified in the parameter. To load another scene,
        //you can either use the parameter above or the name of the scene. e.g.:
        //LoadScene("MainMenu") will load the MainMenu scene. Say that the current scene's
        //build index is 6, and LoadScene(SceneManager.GetActiveScene().buildIndex+5) is
        //used. It will load the scene whose build index is 12, and if
        //LoadScene(SceneManager.GetActiveScene().buildIndex-3) is used, it will load the
        //scene whose build index is 3.
        //SceneManager is a class in Unity that manages scenes a run-time.
        //GetActiveScene() yields the current active scene.
        //buildIndex is the index (integer) of the scene in the build. The index of the
        //scene can be viewed in 'Build Settings...'
    }

    //Function to exit the game from the main menu
    public void Quit()
    {
        Application.Quit(); // Exits the game.
        Debug.Log("Player has exited the game."); //String appears in the engine's console only.
    }
}

