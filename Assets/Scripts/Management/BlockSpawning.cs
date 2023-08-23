// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class BlockSpawning : MonoBehaviour
{
    // Dictates which block is spawned in.
    private int blockSpawnIndex = 0, previousBlockTypeValue = 1000;

    // Iterate move speed value.
    private int previousMoveSpeedValue = 500;

    // Blocks that can be spawned in.
    [SerializeField] private GameObject[] prefabBlocks;

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

    /// <summary> method <c>IterateBlockMoveSpeed</c> Updates block move speed when 500m intervals are achieved.
    public void IterateBlockMoveSpeed()
    {
        // Increase move speed by 25 when 500m travelled.
        if (StaticValues.distanceCovered >= previousMoveSpeedValue)
        {
            // Sets next travel milestone.
            previousMoveSpeedValue += 500;

            // Increases static values.
            StaticValues.blockMoveSpeed += 50;
            StaticValues.distanceIncrease += 10;
        }
    }

    /// <summary> method <c>IterateBlockIndex</c> Increases the needed distance milstone in accordance with players covered distance. </summary>
    public void IterateBlockIndex()
    {
        // When player has travlled another 1K meters, change block type.
        if (StaticValues.distanceCovered >= previousBlockTypeValue)
        {
            previousBlockTypeValue += 1000;

            // Only changes index if block is available.
            if (blockSpawnIndex + 1 < prefabBlocks.Length)
            {
                blockSpawnIndex++;
            }            
        }
    }

    /// <summary> method <c>SpawnObject</c> Uses the current camera world position to spawn an object at the edge of the floor. </summary>
    public void SpawnObject()
    {
        // Get the left and right edges of the camera's view
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 650));
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 650));

        // Calculate the range of possible x values
        float minX = leftEdge.x;
        float maxX = rightEdge.x;

        // Generate a random x value within the range
        float x = Random.Range(minX, maxX);

        // Spawn your object at the desired position
        Vector3 spawnPosition = new Vector3(x, 7f, 700f);

        // Check if the spawn position is already occupied
        Collider[] hitColliders = Physics.OverlapSphere(spawnPosition, 5f);
        while (hitColliders.Length > 0)
        {
            // Generate a new random x value within the range
            x = Random.Range(minX, maxX);
            spawnPosition = new Vector3(x, 7f, 700f);
            hitColliders = Physics.OverlapSphere(spawnPosition, 5f);
        }

        // Check current block index.
        IterateBlockIndex();

        // Load all prefabs in the specified folder
        var prefabCube = prefabBlocks[blockSpawnIndex];
        GameObject newCube = Instantiate(prefabCube, spawnPosition, Quaternion.identity);

        // Allows obj to be easily identifyed.
        newCube.tag = "Block";
    }

    /// <summary> interface <c>ManageObjectSpawning</c> Spawns a new cube (enemy) obj every 4 seconds. </summary>
    public IEnumerator ManageObjectSpawning()
    {
        // Increases block move speed IF distance reached.
        IterateBlockMoveSpeed();

        // Waits then spawns a cube at random position.
        yield return new WaitForSeconds(0.03f);
        SpawnObject();

        // Re-calls this routine.
        StartCoroutine(ManageObjectSpawning());
    }

    // Start is called before the first frame update
    void Start()
    {
        // Fills array with whole block folder.
        prefabBlocks = Resources.LoadAll<GameObject>("Prefabs/Blocks");

        // Begins the  spawing of cube (standard) objs.
        StartCoroutine(ManageObjectSpawning());
    }
}