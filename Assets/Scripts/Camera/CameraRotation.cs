// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private Quaternion cameraStartRot;

    /// <summary> method <c>ChangeCameraRotation</c> Checks if the player is moving, adjusts camera rotation to fit movement. </summary>
    public void ChangeCameraRotation()
    {
        Quaternion targetRotation;
        float lerpSpeed = 5f; // Increase this value to make the rotation faster
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 10f);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -10f);
        }
        else
        {
            targetRotation = cameraStartRot;
            lerpSpeed = 5f; // Use a higher speed when returning to the starting rotation
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * lerpSpeed);
    }



    // Called on script initlization.
    void Awake()
    {
        cameraStartRot = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ChangeCameraRotation();
    }      
}