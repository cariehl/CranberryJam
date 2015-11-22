using UnityEngine;
using System.Collections;

public class Rope : MonoBehaviour {
	public static Rope S;
	public Vector3 objective;
	
	public int num_ropes = 0;
	public bool arrived = false;
	private float temp;
	private float trans;
	private float dist;
	public float radius;
	public bool roping;
	
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
			//rope.transform.position = Vector3.Lerp (transform.position, new Vector3 (objective.x, objective.y, 0f), 0.5f);
		}



		else if (roping) {
			if (arrived) {
				gameObject.GetComponent<Rigidbody2D> ().gravityScale = temp;
				//deactivate rope
			} else {
				Crosshair.S.aiming = false;
				LineRendererScript.S.DrawRope();
				LineRendererScript.S.destination.position = objective;
				dist = Vector3.Distance(transform.position ,new Vector3 (objective.x, objective.y, 0f) );
				if (dist < 1f ) {

					trans = 0f;
					arrived = true;
					roping = false;

					gameObject.GetComponent<Rigidbody2D> ().gravityScale = temp;

				} else {
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
