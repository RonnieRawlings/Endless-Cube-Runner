// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlock : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        // Destroy object when out of view.
        if (transform.position.z < -150f) { Destroy(this.gameObject); }
    }
}
