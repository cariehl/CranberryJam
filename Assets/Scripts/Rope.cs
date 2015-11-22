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
	public Sprite ropeSprite;

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
			rope.sprite = ropeSprite;
			//rope.transform.position = Vector3.Lerp (transform.position, new Vector3 (objective.x, objective.y, 0f), 0.5f);
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
					rope.sprite = null;

					rope.transform.localScale = Vector3.one;
					gameObject.GetComponent<Rigidbody2D> ().gravityScale = temp;

				} else {
					Vector3 temp2 = new Vector3( (objective.x-transform.position.x)*10 -(trans*1) , rope.transform.localScale.y, 0);
					rope.transform.localScale = temp2;

					float distance = Vector3.Distance(objective , transform.position);
					float direction = Vector3.Angle(transform.position, objective);
					float dirx = (objective.x - transform.position.x);

					float angle = Mathf.Acos(dirx/direction)*Mathf.Rad2Deg;

					Debug.Log (angle);
					//rope.transform.rotation = Quaternion.Euler(direction);
					trans += 0.05f;
					transform.position = Vector3.Lerp (transform.position, new Vector3 (objective.x, objective.y, 0f), trans);
					rope.transform.position = Vector3.Lerp (transform.position, new Vector3 (objective.x, objective.y, 0f), 0.5f);
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
