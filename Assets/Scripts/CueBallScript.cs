using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBallScript : MonoBehaviour {

    public Camera mainCamera;
    public LineRenderer aimingLine;

    private Rigidbody body;
    private GameObject gameManager;
    private GameObject cueBall;
    private Component manageTurnScript;
    private RaycastHit hit;

    public float shotPower = 0.05f;

    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        gameManager = GameObject.FindWithTag("GameController");
        cueBall = GameObject.Find("Cue Ball");
        aimingLine = GetComponent<LineRenderer> ();

        aimingLine.enabled = false;
        aimingLine.SetPosition(0, cueBall.transform.position);
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

        if (gameManager.GetComponent<manage_turn>().velocity <= 0.05f)
        {
            Physics.Raycast(cueBall.transform.position, new Vector3(mainCamera.transform.forward.x, 0.0f, mainCamera.transform.forward.z), out hit, 20);

            aimingLine.SetPosition(0, cueBall.transform.position);
            aimingLine.SetPosition(1, hit.point);
        }
	}
}
