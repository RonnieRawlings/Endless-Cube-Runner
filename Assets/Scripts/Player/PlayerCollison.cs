// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollison : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Pauses game, enables game over screen.
        Time.timeScale = 0.0f;
        GameObject.Find("PlayerUI").transform.Find("EndScreen").gameObject.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
