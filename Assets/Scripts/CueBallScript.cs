using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBallScript : MonoBehaviour {

    Rigidbody body;
    public Camera mainCamera;
    GameObject gameManager;
    Component manageTurnScript;

    float shotPower = 0.1f;

    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        gameManager = GameObject.FindWithTag("GameController");
		
	}

    // Physics function to apply force to the ball
    private void HitBall()
    {
            body.AddForce((new Vector3(mainCamera.transform.forward.x,
                0.0f, mainCamera.transform.forward.z) * shotPower), ForceMode.Impulse);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonUp(0) && gameManager.GetComponent<manage_turn>().turnIsActive == false)
        {
            HitBall();
        }
	}
}
