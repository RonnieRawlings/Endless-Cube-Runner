// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollison : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Time.timeScale = 0.0f;
        Debug.Log("Player Collision");
    }
}
