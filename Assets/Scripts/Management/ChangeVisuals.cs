// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVisuals : MonoBehaviour
{
    [SerializeField] private Material[] collection;
    [SerializeField] private int environmentIndex = 0;

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
        if (StaticValues.distanceCovered >= 100 && environmentIndex == 0)
        {
            StartCoroutine(ChangeFloorMaterialColor(GetComponent<MeshRenderer>().material, StaticValues.loadedMaterials[environmentIndex][0].color, 5));
            StartCoroutine(ChangeFloorMaterialColor(transform.GetChild(0).GetComponent<MeshRenderer>().material, StaticValues.loadedMaterials[environmentIndex][1].color, 5));

            environmentIndex++;
        }
        else if (StaticValues.distanceCovered > 500 && environmentIndex == 1)
        {
            StartCoroutine(ChangeFloorMaterialColor(GetComponent<MeshRenderer>().material, StaticValues.loadedMaterials[environmentIndex][0].color, 5));
            StartCoroutine(ChangeFloorMaterialColor(transform.GetChild(0).GetComponent<MeshRenderer>().material, StaticValues.loadedMaterials[environmentIndex][0].color, 5));

            environmentIndex++;
        }
    }
}
