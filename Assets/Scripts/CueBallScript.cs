using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBallScript : MonoBehaviour {

    public Camera mainCamera;

    private Rigidbody body;
    private GameObject gameManager;
    private GameObject cueBall;
    private Component manageTurnScript;
    private LineRenderer aimingLine;
    private RaycastHit hit;

    float shotPower = 0.05f;

    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        gameManager = GameObject.FindWithTag("GameController");
        cueBall = GameObject.Find("Cue Ball");
        aimingLine = GetComponent<LineRenderer> ();
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
            aimingLine.enabled = false;
            HitBall();
        }

        if (gameManager.GetComponent<manage_turn>().turnIsActive == true)
        {
            aimingLine.enabled = true;

            Physics.Raycast(new Vector3((cueBall.transform.position.x + 0.0425f), cueBall.transform.position.y, cueBall.transform.position.z), new Vector3(mainCamera.transform.forward.x, 0.0f, 0.0f), 20);

            aimingLine.SetPosition(0, cueBall.transform.position);
            aimingLine.SetPosition(1, hit.point);

        }
	}
}
