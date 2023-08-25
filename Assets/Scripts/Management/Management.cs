// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Management : MonoBehaviour
{
    // UI Element, current distance player has travelled.
    [SerializeField] private TextMeshProUGUI playerUIDistance;

    // Player model referance.
    [SerializeField] private GameObject playerModel;

    // Prevents incrementing playerUI value multiple times.
    private bool isCoroutineExecuting = false;

    /// <summary> interface <c>IncrementDistanceText</c> Increases the visual meters text by the distance increase over 1 second. </summary>
    public IEnumerator IncrementDistanceText(int targetValue)
    {
        // Stops other routines + removes letters from value.
        isCoroutineExecuting = true;
        int currentValue = int.Parse(playerUIDistance.text.Replace("m", ""));

        // Increments the new value over 1 second.
        while (currentValue < targetValue)
        {
            currentValue++;
            playerUIDistance.text = currentValue.ToString() + "m";
            yield return new WaitForSeconds(1f / StaticValues.distanceIncrease);
        }

        // Allows other routines to begin.
        isCoroutineExecuting = false;
    }

    /// <summary> method <c>UpdateDistance</c> Calculates the current distance travelled, shows it visually using TextMeshProUGUI. </summary>
    public void UpdateDistance()
    {        
        // Set new distance in playerUI.
        if (!isCoroutineExecuting)
        {
            // Calculate new distance.
            StaticValues.distanceCovered = StaticValues.distanceCovered + StaticValues.distanceIncrease;

            // Set new distance.
            StartCoroutine(IncrementDistanceText(StaticValues.distanceCovered));
        }           
    }

    // Called on script initlization.
    private void Awake()
    {       
        // If game has started once, disable start screen + enable elements.
        if (StaticValues.hasStartedOnce) 
        { 
            // Disables start screen.
            playerUIDistance.transform.parent.Find("StartScreen").gameObject.SetActive(false);

            // Enables player + elements.
            playerModel.SetActive(true);
            playerUIDistance.gameObject.SetActive(true);
        }          
    }

    void Start()
    {
        // Sets player highscore to start screen.
        playerUIDistance.transform.parent.GetChild(1).Find("ScoreText").GetComponent<TextMeshProUGUI>().text = 
            "Highscore - " + StaticValues.playerHighscore.ToString() + "m";
    }

    // Update is called once per frame
    void Update()
    {
        // Updates the count when player is active.
        if (playerUIDistance.IsActive()) { UpdateDistance(); }        
    }
}