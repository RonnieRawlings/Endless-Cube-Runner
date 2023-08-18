// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPos : MonoBehaviour
{
    // Provides access to the player model pos.
    private Transform playerTransform;

    // Called once on script initilization.
    void Awake()
    {
        playerTransform = GameObject.Find("PlayerModel").GetComponent<Transform>();
    }

    // Called once per fixed frame.
    void FixedUpdate()
    {
        // Keeps position.
        transform.position = playerTransform.position;
    }
}
