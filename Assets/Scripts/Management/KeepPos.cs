// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPos : MonoBehaviour
{
    // Provides access to the player model pos.
    [SerializeField] private Transform playerTransform;

    // Called once per fixed frame.
    void FixedUpdate()
    {
        // Keeps position.
        transform.position = playerTransform.position;
    }
}
