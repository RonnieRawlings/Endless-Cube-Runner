// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using Unity.VisualScripting;
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
    public static Dictionary<int, Material[]> loadedMaterials;

    // Player highscore, saved using playerprefs.
    public static int playerHighscore;

    /// <summary> constructor <c>StaticValues</c> Sets up variables on scene load. </summary>
    static StaticValues() 
    {
        // Loads environment materials from resources.
        SetUpMaterials();

        // Loads highscore.
        playerHighscore = PlayerPrefs.GetInt("playerHighscore");
    }

    /// <summary> static method <c>SetUpMaterials</c> Fills the dictionary with environemnt indexs + materials. </summary>
    public static void SetUpMaterials()
    {
        loadedMaterials = new Dictionary<int, Material[]>();
        for (int folderAmount = 0; folderAmount < 4; folderAmount++)
        {
            loadedMaterials.Add(folderAmount, Resources.LoadAll<Material>("Materialss/" + folderAmount.ToString()));
        }
    }

    /// <summary> static method <c>SaveValues</c> Uses Unity player prefs to save values. </summary>
    public static void SaveValues()
    {
        PlayerPrefs.SetInt("playerHighscore", playerHighscore);
    }

    /// <summary> static method <c>ResetValues</c> Returns all script values to orginal state. </summary>
    public static void ResetValues()
    {
        distanceCovered = 0;
        distanceIncrease = 20;
        blockMoveSpeed = 100;
    }
}
