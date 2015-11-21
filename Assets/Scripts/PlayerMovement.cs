using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
	// Target jump height in terms of units
	public float targetJumpHeight = 3.2f;

	float jumpForce;
    Rigidbody2D rgbd;
    bool grounded = false;
    Animator anim;

	// Use this for initialization
	void Start ()
	{
		jumpForce = Mathf.Sqrt(2f * targetJumpHeight * (-1 * Physics2D.gravity.y));
		rgbd = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
        anim.SetBool("running", false);
        anim.SetBool("facing_left", false);
    }
	
	// Update is called once per frame
	void Update ()
	{
        anim.SetBool("jumping", !grounded);
        if (Input.GetAxis("Horizontal") > 0) {
            anim.SetBool("facing_left", false);
        }
        if (Input.GetAxis("Horizontal") < 0) {
            anim.SetBool("facing_left", true);
        }
        if (grounded) {
            if (Input.GetButtonDown("Jump")) {
				Debug.Log("Jumping!");
				rgbd.velocity += new Vector2(0f, jumpForce);
				grounded = false;
            }
            if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0) {
                anim.SetBool("running", true);
            } else
                anim.SetBool("running", false);
        }
        rgbd.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rgbd.velocity.y);
	}

    void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Ground") {
			Debug.Log("Collide");
			grounded = true;
		}
    }
}