// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Movement variables, move speed.
    [SerializeField] private float speed = 5.0f;

    /// <summary> method <c>BasicMovement</c> Allows the user to use the horizontal set keys to move the player char. </summary>
    public void BasicMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    }

    // Called every fixed frame, useful in physics calcs.
    private void FixedUpdate()
    {
        BasicMovement();
    }
}
