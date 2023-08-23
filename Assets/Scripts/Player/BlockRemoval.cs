// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRemoval : MonoBehaviour
{
    /// <summary> method <c>BlockDestroy</c> Uses an OverlapSphere to remove all blocks within a set radius. </summary>
    public void BlockDestroy()
    {
        // Radius of the OverlapSphere
        float radius = 100f;

        // Find all colliders that intersect with the OverlapSphere
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        // Loop through all hit colliders
        foreach (Collider hitCollider in hitColliders)
        {
            // Check if the object has the tag "Block"
            if (hitCollider.CompareTag("Block"))
            {
                // Remove the object from the scene
                Destroy(hitCollider.gameObject);
            }
        }
    }

    // Called once on object enable.
    void OnEnable()
    {
        BlockDestroy();
    }

    public float radius = 50f; // Radius of the OverlapSphere

    void OnDrawGizmos()
    {
        // Draw a wireframe sphere at the player's position with the specified radius
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
