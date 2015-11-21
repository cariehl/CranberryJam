using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

    public GameObject player;
    public float upperBound;
	public float lowerBound;
	public float camMinimumOffset;

	BoxCollider2D playerCollider;
	float playerTopY;
	float playerBotY;
	float playerHeight;
	float camMinimumY;

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
			} else {
				// Dead
				StartCoroutine(player.GetComponent<PlayerMovement>().FallOut());
			}
		}
	}
}
