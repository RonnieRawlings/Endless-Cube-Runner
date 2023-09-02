// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollison : MonoBehaviour
{
    // Time the player flashes colours for.
    private float flashDuration = 0.2f;

    private void OnTriggerEnter(Collider other)
    {
        // Pauses game, enables game over screen.
        Time.timeScale = 0.0f;
        GameObject.Find("PlayerUI").transform.Find("EndScreen").gameObject.SetActive(true);
    }

    /// <summary> interface <c>InvincibleFlashing</c> Visually shows that the player is invincible for these frames. </summary>
    public IEnumerator InvincibleFlashing()
    {
        // Finds players renderer comp.
        Renderer playerRenderer = GetComponent<Renderer>();

        // Alternates players visability for set period.
        while (StaticValues.distanceCovered < 1000)
        {
            playerRenderer.enabled = false;
            yield return new WaitForSeconds(flashDuration);
            playerRenderer.enabled = true;
            yield return new WaitForSeconds(flashDuration);
        }
    }
}
