// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawning : MonoBehaviour
{
    /// <summary> method <c>DebugCameraField</c> Places markers where the camera bounds are, shows spawning zone. </summary>
    public void DebugCameraField(float minX, float maxX)
    {
        // Removes the current markers from the scene.
        GameObject[] allMarkers = GameObject.FindGameObjectsWithTag("Marker");
        foreach (GameObject marker in allMarkers)
        {
            Destroy(marker);
        }

        // Spawns in new markers from resources.
        var prefabCameraMarker = Resources.Load<GameObject>("Prefabs/Marker");
        GameObject firstMarker = Instantiate(prefabCameraMarker, new Vector3(minX, 7f, 150f), Quaternion.identity);
        GameObject secondMarker = Instantiate(prefabCameraMarker, new Vector3(maxX, 7f, 150f), Quaternion.identity);
        firstMarker.tag = "Marker";
        secondMarker.tag = "Marker";
    }

    /// <summary> method <c>SpawnObject</c> Uses the current camera world position to spawn an object at the edge of the floor. </summary>
    public void SpawnObject()
    {
        // Get the left and right edges of the camera's view
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 100));
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 100));

        // Calculate the range of possible x values
        float minX = leftEdge.x;
        float maxX = rightEdge.x;

        // Generate a random x value within the range
        float x = Random.Range(minX, maxX);

        // Spawn your object at the desired position
        Vector3 spawnPosition = new Vector3(x, 7f, 150f);
        var prefabCube = Resources.Load<GameObject>("Prefabs/MovingBlock (Standard)");
        Instantiate(prefabCube, spawnPosition, Quaternion.identity);
    }

    /// <summary> interface <c>ManageObjectSpawning</c> Spawns a new cube (enemy) obj every 4 seconds. </summary>
    public IEnumerator ManageObjectSpawning()
    {
        // Waits then spawns a cube at random position.
        yield return new WaitForSeconds(0.125f);
        SpawnObject();

        // Re-calls this routine.
        StartCoroutine(ManageObjectSpawning());
    }

    // Start is called before the first frame update
    void Start()
    {
        // Begins the  spawing of cube (standard) objs.
        StartCoroutine(ManageObjectSpawning());
    }
}
