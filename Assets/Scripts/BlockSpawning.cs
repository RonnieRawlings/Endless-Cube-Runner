// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawning : MonoBehaviour
{
    private bool setMarkers = false;

    /// <summary> method <c>SpawnObject</c> Uses the current camera world position to spawn an object at the edge of the floor. </summary>
    public void SpawnObject()
    {
        // Get the left and right edges of the camera's view
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 45));
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 45));

        // Calculate the range of possible x values
        float minX = leftEdge.x;
        float maxX = rightEdge.x;

        // Generate a random x value within the range
        float x = Random.Range(minX, maxX);

        if (!setMarkers)
        {
            var prefabCameraMarker = Resources.Load<GameObject>("Prefabs/Marker");
            Instantiate(prefabCameraMarker, new Vector3(minX, 7f, 150f), Quaternion.identity);
            Instantiate(prefabCameraMarker, new Vector3(maxX, 7f, 150f), Quaternion.identity);

            setMarkers = true;
        }

        // Spawn your object at the desired position
        Vector3 spawnPosition = new Vector3(x, 7f, 150f);
        var prefabCube = Resources.Load<GameObject>("Prefabs/MovingBlock (Standard)");
        Instantiate(prefabCube, spawnPosition, Quaternion.identity);
    }

    /// <summary> interface <c>ManageObjectSpawning</c> Spawns a new cube (enemy) obj every 4 seconds. </summary>
    public IEnumerator ManageObjectSpawning()
    {
        // Waits then spawns a cube at random position.
        yield return new WaitForSeconds(2.0f);
        SpawnObject();

        // Waits again, re-calls this routine.
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(ManageObjectSpawning());
    }

    // Start is called before the first frame update
    void Start()
    {
        // Begins the  spawing of cube (standard) objs.
        StartCoroutine(ManageObjectSpawning());
    }
}
