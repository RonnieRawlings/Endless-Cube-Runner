// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticValues
{
    public static int distanceCovered = 0, distanceIncrease = 20;

    /// <summary> static method <c>ResetValues</c> Returns all script values to orginal state. </summary>
    public static void ResetValues()
    {
        distanceCovered = 0;
        distanceIncrease = 20;
    }
}
