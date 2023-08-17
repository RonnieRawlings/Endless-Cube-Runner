// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    // Movement variables, move speed.
    private float speed = 50; 

    // Update is called once per frame
    void Update()
    {
        // Once spawned in, move block across the plane.
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
}
