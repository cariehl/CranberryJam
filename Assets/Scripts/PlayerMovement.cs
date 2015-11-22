using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    static public PlayerMovement S;

    void Awake() {
        S = this;
    }


    public float speed = 1f;
	// Target jump height in terms of units
	public float targetJumpHeight = 3.2f;
	
	float jumpForce;
    Rigidbody2D rgbd;
    bool grounded = false;
    Animator anim;
    [HideInInspector] public bool can_move;
	

	// Use this for initialization
	void Start ()
	{
        Cursor.visible = false;
        DontDestroy.S.score = 0;
        DontDestroy.S.level = Application.loadedLevel;
        rgbd = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		
		targetJumpHeight *= rgbd.gravityScale;
		jumpForce = Mathf.Sqrt(2f * targetJumpHeight * Mathf.Abs(Physics2D.gravity.y));
		anim.SetBool("running", false);
        anim.SetBool("facing_left", false);
        can_move = true;
    }
	
	// Update is called once per frame
	void Update ()
	{
        if (can_move) {
            anim.SetBool("jumping", !grounded);
            if (Input.GetAxis("Horizontal") > 0) {
                anim.SetBool("facing_left", false);
            }
            if (Input.GetAxis("Horizontal") < 0) {
                anim.SetBool("facing_left", true);
            }
            if (grounded) {
                if (Input.GetButtonDown("Jump")) {
                    rgbd.velocity += new Vector2(0f, 1f * jumpForce);
                    grounded = false;
                }
                if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0) {
                    anim.SetBool("running", true);
                } else
                    anim.SetBool("running", false);
            }
        }
		
        rgbd.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rgbd.velocity.y);
	}

	// Cause the player to fall out of the world
	public IEnumerator FallOut(bool tutorial)
	{
		this.GetComponent<BoxCollider2D>().enabled = false;
		yield return new WaitForSeconds(1.0f);
        if (!tutorial && DontDestroy.S.score > PlayerPrefs.GetInt("highscore")) {
            Application.LoadLevel("HighScore");
        } else
            Application.LoadLevel("GameOver");
    }

    void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Ground") {
			// Checks to see if we hit the collider from the top
			if (coll.enabled) {
				coll.transform.parent.GetComponent<platform>().touched = true;
				grounded = true;
			}
		}
    }

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Coin") {
			DontDestroy.S.score += 5;
			Destroy(coll.gameObject);
		} else if (coll.gameObject.tag == "Rope") {
			Rope.S.num_ropes++;
			Destroy(coll.gameObject);
		}
	}

    void OnDestroy() {
        Cursor.visible = true;
    }
}