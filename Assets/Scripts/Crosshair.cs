using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {
	static public Crosshair S;

	private bool hitch = false;
	public Vector3 cr_objective ;
	public GameObject projectile;
	public bool aiming;
	public Sprite target;
	Camera cam;

	//Get the current mouse position in 2d Screen coords
	Vector3 mousePos2D;

	void Awake(){
		S = this;
	}

	void Start(){
		cam = Camera.main;
	}

	void Update()
	{

		if (!aiming) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = null;
		}
		else {
			gameObject.GetComponent<SpriteRenderer> ().sprite = target;
			mousePos2D = Input.mousePosition;
			//Conver the position to 3d coords
			mousePos2D.z = -Camera.main.transform.position.z;

			Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);
			//Find the delta from the launchPos to the mousePos3d
			Vector3 mouseDelta = mousePos3D - Rope.S.transform.position;
			//Limit mouseDelta to get the taduis of the slinshot Sphere Collider


			float maxMagnitude = Rope.S.radius;
			if (mouseDelta.magnitude > maxMagnitude) {
				mouseDelta.Normalize ();
				mouseDelta *= maxMagnitude;
			}
			//Move the projectile to this new position
			Vector3 projPos = Rope.S.transform.position + mouseDelta;
			projectile.transform.position = projPos;

			cr_objective = projectile.transform.position;
			if (Rope.S.num_ropes > 0) {
				if (Input.GetButtonDown ("Fire3")) {
					if (!hitch) {
						Rope.S.objective = cr_objective;
						Rope.S.moveToRope ();
					} else { 
						Rope.S.objective = cr_objective;
						Rope.S.moveToRope ();
					}
				}
			}
		}
		this.aiming = Crosshair.S.aiming;
	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		Debug.Log("detected CH col");
		if (coll.tag.Equals ("Hitch") ) {
			Debug.Log ("A Hitch!");
			hitch = true;
			cr_objective = coll.transform.position;
		}

	}
	

	void OnTriggerExit2D(Collider2D coll)
	{
		hitch = false;
	}
}
