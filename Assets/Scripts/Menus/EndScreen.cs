// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
        finalScore.text = "FINAL SCORE - " + currentScoreText.text;

        // Extracts actual numerical score.
        int score = int.Parse(Regex.Match(finalScore.text, @"\d+").Value);

        // Sets new highscore if beaten.
        if (score > StaticValues.playerHighscore)
        {
            StaticValues.playerHighscore = score;
        }

        // Saves highscore, even if it isn't new.
        StaticValues.SaveValues();
    }
}
