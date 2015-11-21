using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

    GameObject player;
    public float upperBound = 0.8f;
    float x;
    float z;
	float playerTopY;
	float playerHeight;

    // Use this for initialization
    void Start ()
	{
        player = GameObject.Find("Player");
        x = transform.position.x;
        z = transform.position.z;
		playerHeight = player.GetComponent<SpriteRenderer>().sprite.bounds.size.y;
	}
	
	// Update is called once per frame
	void Update ()
	{
		playerTopY = player.transform.position.y + playerHeight;
		float camHeightY = Camera.main.ViewportToWorldPoint(new Vector3(0, upperBound, Camera.main.nearClipPlane)).y;
        if (playerTopY > camHeightY) {
			transform.position += new Vector3(0, playerTopY - camHeightY, 0);
        }
	}
}
