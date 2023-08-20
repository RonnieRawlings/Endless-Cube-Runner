// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    void OnEnable()
    {
        // Gets access to text components.
        TextMeshProUGUI finalScore = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI currentScoreText = transform.parent.GetChild(0).GetComponent<TextMeshProUGUI>();


        // Sets players final score onto game over screen.

        finalScore.text = "FINAL SCORE - " +  currentScoreText.text;
    }
}
