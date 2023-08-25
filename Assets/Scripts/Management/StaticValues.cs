// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticValues
{
    // Start game values, prevents startScreen re-appearing.
    public static bool hasStartedOnce = false;

    // Distance values, travel amount + travel speed.
    public static int distanceCovered = 0, distanceIncrease = 20;

    // Block movement values.
    public static int blockMoveSpeed = 100;

    // Loaded material folder.
    public static Material[] loadedMaterials;

    /// <summary> constructor <c>StaticValues</c> Sets up variables on scene load. </summary>
    static StaticValues() 
    {
        loadedMaterials = Resources.LoadAll<Material>("Materialss");
    }

    /// <summary> static method <c>ResetValues</c> Returns all script values to orginal state. </summary>
    public static void ResetValues()
    {
        distanceCovered = 0;
        distanceIncrease = 20;
        blockMoveSpeed = 100;
    }
}
