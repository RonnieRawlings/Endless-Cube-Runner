// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    // Movement variables, move speed.
    [SerializeField] private float speed;

    // Called on script initlization.
    private void Awake()
    {
        // Adjust movement speed.
        speed = StaticValues.blockMoveSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Once spawned in, move block across the plane.
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
}
