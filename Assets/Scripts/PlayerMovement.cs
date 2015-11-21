using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed = 1;
    public float jumpforce = 69;
    private Rigidbody2D rgbd;
    bool grounded = false;

	// Use this for initialization
	void Start () {
        rgbd = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (grounded) {
            if (Input.GetButtonDown("Jump")) {
                rgbd.AddForce(Vector2.up * jumpforce);
                grounded = false;
            }
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
