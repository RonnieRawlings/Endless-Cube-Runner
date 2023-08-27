// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePause : MonoBehaviour
{
    // Obj for the pause menu.
    [SerializeField] GameObject pauseMenu;

    /// <summary> method <c>CheckForPause</c> Keeps track of player pause status, pauses + resumes the game. </summary>
    public void CheckForPause()
    {
        // Checks for pause input, changes game status when recived.
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            // Sets the menu to the status it isn't.
            pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckForPause();
    }
}
