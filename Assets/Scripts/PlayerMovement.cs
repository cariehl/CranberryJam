using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
	// Target jump height in terms of units
    public float targetJumpHeight = 3.2f;
	private float jumpForce;
    private Rigidbody2D rgbd;
    bool grounded = false;

	// Use this for initialization
	void Start ()
	{
		jumpForce = Mathf.Sqrt(2f * targetJumpHeight * (-1 * Physics2D.gravity.y));
		rgbd = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (grounded) {
            if (Input.GetButtonDown("Jump")) {
				rgbd.velocity += new Vector2(0f, jumpForce);
                grounded = false;
            }
        }
        rgbd.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rgbd.velocity.y);
	}

    void OnCollisionEnter2D(Collision2D coll)
	{
        if (coll.gameObject.tag == "Ground") {
            if (coll.enabled)
                grounded = true;
        }
    }
}
