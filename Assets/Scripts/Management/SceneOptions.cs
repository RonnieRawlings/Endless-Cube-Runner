// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOptions : MonoBehaviour
{
    [SerializeField] private GameObject playerModel, playerUI;

    /// <summary> method <c>PlayGame</c> Disables startMenu, unpauses game, & begins spawning. </summary>
    public void PlayGame()
    {
        // Enables player + distance tracker.
        playerModel.SetActive(true);
        playerUI.transform.Find("DistanceCoveredText").gameObject.SetActive(true);
        
        // Disables start menu.
        playerUI.transform.Find("StartScreen").gameObject.SetActive(false);

        // Prevents screen re-appearing.    
        StaticValues.hasStartedOnce = true;
    }

    /// <summary> method <c>ToggleQuickStart</c> Used to toggle static variable, quicks starts game next load. </summary>
    public void ToggleQuickStart()
    {
        StaticValues.shouldQuickStart = true;
    }

    /// <summary> method <c>QuickStart</c> Starts the QuickStart coroutine from button press. </summary>
    public void QuickStart()
    {
        StartCoroutine(QuickStartCoroutine());
    }

    /// <summary> interface <c>QuickStart</c> Zooms the player to the 1000m mark, allows the game to start at a higher speed. </summary>
    public IEnumerator QuickStartCoroutine()
    {
        // Enables player + distance tracker.
        playerModel.SetActive(true);
        playerUI.transform.Find("DistanceCoveredText").gameObject.SetActive(true);

        // Disables start menu.
        playerUI.transform.Find("StartScreen").gameObject.SetActive(false);

        // Increases values for set period.
        StaticValues.blockMoveSpeed = 400;
        StaticValues.distanceIncrease = 100;

        // Prevents player movement/rotation.
        playerModel.GetComponent<PlayerMovement>().enabled = false;
        Camera.main.GetComponent<CameraRotation>().enabled = false;

        // Starts player invincible flashing.
        StartCoroutine(playerModel.GetComponent<PlayerCollison>().InvincibleFlashing());

        // Continues block removal around player.
        while (StaticValues.distanceCovered < 1000)
        {
            playerModel.GetComponent<BlockRemoval>().BlockDestroy(40.0f);
            yield return new WaitForEndOfFrame();
        }

        // Resets altered values.
        StaticValues.blockMoveSpeed = 150;
        StaticValues.distanceIncrease = 30;

        // Re-enables player movement/rotation.
        playerModel.GetComponent<PlayerMovement>().enabled = true;
        Camera.main.GetComponent<CameraRotation>().enabled = true;

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
        // Saves highscore to playerprefs.
        StaticValues.SaveValues();
        
        // Closes the application.
        Application.Quit();
    }
}
