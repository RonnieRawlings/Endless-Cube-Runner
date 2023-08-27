// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    // Called once when made active.
    void OnEnable()
    {
        Time.timeScale = 0.0f;
    }

    // Called once when made inactive.
    void OnDisable()
    {
        Time.timeScale = 1.0f;
    }
}
