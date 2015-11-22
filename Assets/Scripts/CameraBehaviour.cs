using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

    public GameObject player;
    public float upperBound;
	public float lowerBound;
	public float camMinimumOffset;
    public bool tutorial = false;

	BoxCollider2D playerCollider;
	// Top and bottom of player frame
	float playerTopY;
	float playerBotY;
	// How tall the player is
	float playerHeight;
	// Minimum amount the camera can scroll down to
	float camMinimumY;
	// Zone that will kill the player if they get too far down
	float killzone
	{
		get
		{
			return Camera.main.ViewportToWorldPoint(new Vector3(0f, -0.06f, Camera.main.nearClipPlane)).y;
        }
	}

    // Use this for initialization
    void Start ()
	{
		camMinimumY = Camera.main.ViewportToWorldPoint(new Vector3(0, lowerBound, Camera.main.nearClipPlane)).y - camMinimumOffset;
        playerCollider = player.GetComponent<BoxCollider2D>();
		playerHeight = playerCollider.bounds.size.y;
	}
	
	// Update is called once per frame
	void Update ()
	{
		playerTopY = playerCollider.bounds.min.y + playerHeight;
		playerBotY = playerCollider.bounds.max.y - playerHeight;
		float camTopY = Camera.main.ViewportToWorldPoint(new Vector3(0, upperBound, Camera.main.nearClipPlane)).y;
		float camBotY = Camera.main.ViewportToWorldPoint(new Vector3(0, lowerBound, Camera.main.nearClipPlane)).y;
        if (playerTopY > camTopY) {
			Vector3 moveAmt = new Vector3(0, playerTopY - camTopY, 0);
            transform.Translate(moveAmt);
			if (camBotY - camMinimumY > camMinimumOffset) {
				camMinimumY += moveAmt.y;
			}
        } else if (playerBotY < camBotY) {
			if (playerBotY >= camMinimumY) {
				transform.Translate(new Vector3(0, playerBotY - camBotY, 0));
			} else if (playerBotY < killzone) {
				// Dead
				//Debug.Log("Killzone");
				StartCoroutine(player.GetComponent<PlayerMovement>().FallOut(tutorial));
			}
		}
	}
}
