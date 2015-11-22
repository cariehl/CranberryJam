using UnityEngine;
using System.Collections;

public class Rope : MonoBehaviour {
	//Singleton Class
	public static Rope S;

	public int num_ropes = 0;
	public Vector3 objective;
	public float radius = 6;
	public float ropeSpeed = 0.005f;
	public bool ________________________;
	public bool roping;	
	public bool arrived = false;
	private float temp;
	private float trans;
	private float dist;


	void Awake()
	{
		S = this;
	}


	void Update () {

		//if (Input.GetButtonDown ("Fire3")) {
			Crosshair.S.aiming = true;
		//} else 
		if (roping) {
			if (arrived) {
				gameObject.GetComponent<Rigidbody2D> ().gravityScale = temp;
			} else {
				Crosshair.S.aiming = false;
				LineRendererScript.S.destination.position = objective;
				LineRendererScript.S.DrawRope ();
				dist = Vector3.Distance (transform.position, new Vector3 (objective.x, objective.y, 0f));
				if (dist < 2f) {

					trans = 0f;
					arrived = true;
					roping = false;
					gameObject.GetComponent<Rigidbody2D> ().gravityScale = temp;

				} else {
					trans += ropeSpeed;
					transform.position = Vector3.Lerp (transform.position, new Vector3 (objective.x, objective.y, 0f), trans);
				}
			}
		} else { //roping
		//Disable rope

		}
	}

	public void moveToRope()
	{
		roping = true;
		arrived = false;
		temp = gameObject.GetComponent<Rigidbody2D>().gravityScale;
		gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
		trans = 0.0f;
	
	}
}
