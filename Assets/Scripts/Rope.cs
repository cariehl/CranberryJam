using UnityEngine;
using System.Collections;

public class Rope : MonoBehaviour {
	static public Rope S;
	public Vector3 objective;
	
	public int num_ropes = 1;
	public bool arrived = false;
	private float temp;
	private float trans;
	private float dist;
	public float radius;
	public bool roping;

	public SpriteRenderer rope;

	void Awake()
	{
		S = this;
	}

	// Use this for initialization
	void Start () {
		//radius = 0.45f;//GetComponent<CircleCollider2D> ().radius;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Fire3")) {
			Crosshair.S.aiming = true;
		}



		else if (roping) {
			if (arrived) {
				gameObject.GetComponent<Rigidbody2D> ().gravityScale = temp;
				//deactivate rope
			} else {
				Crosshair.S.aiming = false;
				dist = Vector3.Distance(transform.position ,new Vector3 (objective.x, objective.y, 0f) );
				if (dist < 0.3f ) {

					trans = 0f;
					arrived = true;
					roping = false;

					gameObject.GetComponent<Rigidbody2D> ().gravityScale = temp;

				} else {
					Vector3 temp2 = new Vector3(rope.transform.localScale.x + (trans*1) , rope.transform.localScale.y, 0);
					rope.transform.localScale = temp2;
					trans += 0.0005f;
					transform.position = Vector3.Lerp (transform.position, new Vector3 (objective.x, objective.y, 0f), trans);
				}
			}
		}
	}

	public void moveToRope()
	{
		roping = true;
		arrived = false;
		temp = gameObject.GetComponent<Rigidbody2D>().gravityScale;
		gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
		trans = 0.0f;
		//transform.position = Vector3.Lerp(transform.position, target.position, );
	
	}
}
