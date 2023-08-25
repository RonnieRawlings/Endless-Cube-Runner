// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVisuals : MonoBehaviour
{
    [SerializeField] private Material[] collection;

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
        if (StaticValues.distanceCovered >= 100)
        {
            StartCoroutine(ChangeFloorMaterialColor(GetComponent<MeshRenderer>().material, StaticValues.loadedMaterials[2].color, 5));
        }
    }
}
