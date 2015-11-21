using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

    public GameObject player;
    public float upperBound;

	BoxCollider2D playerCollider;
	float playerTopY;
	float playerHeight;

    // Use this for initialization
    void Start ()
	{
		playerCollider = player.GetComponent<BoxCollider2D>();
		playerHeight = playerCollider.bounds.size.y;
	}
	
	// Update is called once per frame
	void Update ()
	{
		playerTopY = playerCollider.bounds.min.y + playerHeight;
		float camHeightY = Camera.main.ViewportToWorldPoint(new Vector3(0, upperBound, Camera.main.nearClipPlane)).y;
        if (playerTopY > camHeightY) {
			transform.position += new Vector3(0, playerTopY - camHeightY, 0);
        }
	}
}
