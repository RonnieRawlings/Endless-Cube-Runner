// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOptions : MonoBehaviour
{
    /// <summary> method <c>PlayGame</c> Disables startMenu, unpauses game, & begins spawning. </summary>
    public void PlayGame()
    {
        // Un-pauses game, disables start menu.
        Time.timeScale = 1.0f;
        GameObject.Find("PlayerUI").transform.Find("StartScreen").gameObject.SetActive(false);

        // Prevents screen re-appearing.    
        StaticValues.hasStartedOnce = true;
    }

    /// <summary> method <c>LoadScene</c> Takes a given scene name, loads that scene. </summary>
    public void LoadScene(string sceneName)
    {
        // Returns all static values to original state.
        StaticValues.ResetValues();

        // Resumes game + re-loads scene.
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(sceneName);
    }

    /// <summary> method <c>QuitGame</c> Exits the application, used for button presses. </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
