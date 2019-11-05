using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manage_turn : MonoBehaviour {

    public bool turnIsActive = false;
    float velocity = 0.0f;

    public GameObject cueBall;

    public Cinemachine.CinemachineFreeLook aimingCamera;
    public Cinemachine.CinemachineVirtualCamera spiderCam;
    

	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        velocity = cueBall.GetComponent<Rigidbody>().velocity.magnitude;
        if (velocity > 0 && turnIsActive == false)
        {
            ActivateTurn();
        }

        if (velocity < 0.05 && turnIsActive == true)
        {
            DeactivateTurn();
        }
	}

    // Called when the cue ball begins moving (turn is started)
    void ActivateTurn()
    {
        turnIsActive = true;
        SwapCameraPriority();
    }


    // Called when the cue ball stops moving (turn ends, return to aiming)
    void DeactivateTurn()
    {
        turnIsActive = false;
        SwapCameraPriority();
    }


    // Called when turn starts and ends. Swaps priority between aim camera and shot
    // camera.
    void SwapCameraPriority()
    {
        if (aimingCamera.Priority > spiderCam.Priority)
        {
            aimingCamera.Priority--;
            spiderCam.Priority++;
        }
        else
        {
            spiderCam.Priority--;
            aimingCamera.Priority++;
        }
    }
}
