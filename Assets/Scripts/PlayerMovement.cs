using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed = 1;
    public float jumpforce = 69;
    private Rigidbody2D rgbd;
    bool grounded = false;
    Animator anim;

	// Use this for initialization
	void Start () {
        rgbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("running", false);
        anim.SetBool("facing_left", false);
    }
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("jumping", !grounded);
        if (Input.GetAxis("Horizontal") > 0) {
            anim.SetBool("facing_left", false);
        }
        if (Input.GetAxis("Horizontal") < 0) {
            anim.SetBool("facing_left", true);
        }
        if (grounded) {
            if (Input.GetButtonDown("Jump")) {
                rgbd.AddForce(Vector2.up * jumpforce);
                grounded = false;
            }
            if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0) {
                anim.SetBool("running", true);
            }
            else
                anim.SetBool("running", false);
        }
        rgbd.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rgbd.velocity.y);
	}

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Ground") {
            if (coll.enabled)
                grounded = true;
        }

    }
}
