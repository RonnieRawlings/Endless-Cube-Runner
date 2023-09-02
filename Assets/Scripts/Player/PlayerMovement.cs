// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float smoothTime = 0.00001F;
    private Vector3 velocity = Vector3.zero;

    /// <summary> method <c>BasicMovement</c> Allows the user to use the horizontal set keys to move the player char. </summary>
    public void BasicMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 targetPosition = transform.position + Vector3.right * horizontalInput * Time.deltaTime * StaticValues.playerMoveSpeed;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    /// <summary> method <c>SetRotation</c> Resets pos axis and aligns rotation with main camera. </summary>
    public void SetRotation()
    {
        // Prevent unnessecary change in movement.
        Vector3 position = transform.position;
        position.y = 0;
        position.z = 15;
        transform.position = position;

        // Sets Z rotation to camera's.
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y,
            Camera.main.transform.rotation.eulerAngles.z);
    }

    // Called every fixed frame, useful in physics calcs.
    private void FixedUpdate()
    {
        // Allow player to move player obj.
        BasicMovement();

        // Adjust rotation to match camera.
        SetRotation();
    }
}
