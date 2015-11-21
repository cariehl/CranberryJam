using UnityEngine;
using System.Collections;

public class Rope : MonoBehaviour {
	static public Rope S;
	public Vector3 objective;
	
	public int num_ropes = 1;
	private bool arrived;
	private float temp;
	private float trans;
	public float radius;

	void Awake()
	{
		S = this;
	}

	// Use this for initialization
	void Start () {
		radius = 0.45f;//GetComponent<CircleCollider2D> ().radius;
	}
	
	// Update is called once per frame
	void Update () {
		if (arrived) {
			gameObject.GetComponent<Rigidbody2D> ().gravityScale = temp;
		} 
		else {
			if (trans > 0.9f){
				trans = 0f;
				arrived = true;
			}
			else {
				trans += 0.1f;
				transform.position = Vector3.Lerp(transform.position, new Vector3(objective.x, objective.y, 0f), trans);
			}
		}
	}

	public void moveToRope()
	{
		arrived = false;
		temp = gameObject.GetComponent<Rigidbody2D>().gravityScale;
		gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
		trans = 0.0f;
		//transform.position = Vector3.Lerp(transform.position, target.position, );
	
	}
}
