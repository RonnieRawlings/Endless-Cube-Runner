// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Object to follow + velocity ref.
    private Transform playerTransform;
    private Vector3 velocity = Vector3.zero;

    // Movement fields, delay speed.
    [SerializeField] private float smoothTime;

    // Called on script initlization.
    void Awake()
    {
        playerTransform = GameObject.Find("PlayerModel").GetComponent<Transform>();
    }

    // Called once every frame, just after update.
    void FixedUpdate()
    {
        // Smoothly moves the camera behind the player.
        Vector3 targetPosition = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}