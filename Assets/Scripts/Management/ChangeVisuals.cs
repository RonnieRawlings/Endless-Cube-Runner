// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVisuals : MonoBehaviour
{
    [SerializeField] private Material[] collection;
    private int environmentIndex = 0, lastInterval = 500;

    /// <summary> method <c>SwitchEnvironments</c> Changes the environment when player travels a set distance. </summary>
    public void SwitchEnvironments()
    {
        // Prevents attempted environment change.
        if (environmentIndex == StaticValues.loadedMaterials.Count) { return; }

        // Set distance has been covered, change environment.
        if (StaticValues.distanceCovered > lastInterval)
        {
            // Material selection depends on folder size.
            if (StaticValues.loadedMaterials[environmentIndex].Length == 2)
            {
                // Change each enviornmnet.
                StartCoroutine(ChangeFloorMaterialColor(GetComponent<MeshRenderer>().material, StaticValues.loadedMaterials[environmentIndex][0].color, 5));
                StartCoroutine(ChangeFloorMaterialColor(transform.GetChild(0).GetComponent<MeshRenderer>().material, StaticValues.loadedMaterials[environmentIndex][1].color, 5));
            }
            else
            {
                StartCoroutine(ChangeFloorMaterialColor(GetComponent<MeshRenderer>().material, StaticValues.loadedMaterials[environmentIndex][0].color, 5));
                StartCoroutine(ChangeFloorMaterialColor(transform.GetChild(0).GetComponent<MeshRenderer>().material, StaticValues.loadedMaterials[environmentIndex][0].color, 5));
            }

            // Increase index + distance to cover.
            environmentIndex++;
            lastInterval = lastInterval * 2;
        }
    }

    /// <summary> interface <c>UpdateFloorMaterialDynamic</c> Changes the floor material to another, dynamiclly. </summary>
    IEnumerator ChangeFloorMaterialColor(Material floorMaterial, Color targetColor, float duration)
    {
        // Material starting colour.
        Color startColor = floorMaterial.color;

        // Slowly transitions the colours.
        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            floorMaterial.color = Color.Lerp(startColor, targetColor, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Sets the final floor material.
        floorMaterial.color = targetColor;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchEnvironments();
    }
}
