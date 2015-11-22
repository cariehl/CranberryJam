using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {
	static public Crosshair S;

	private bool hitch = false;
	public Vector3 cr_objective ;
	public GameObject projectile;
	public bool aiming;
	public Sprite target;
	public Sprite cdSprite;
	Camera cam;

	public Sprite hitch_off;
	public Sprite hitch_on;

	public float cooldown;

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
		if(cooldown <= 1) {
			gameObject.GetComponent<SpriteRenderer>().color = Color.green;
		}
		cooldown -= Time.deltaTime;
		if (!aiming) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = null;
			Cursor.visible = true;
		}
		else {
			Cursor.visible = false;
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

			if (Rope.S.num_ropes > 0) {
				if (Input.GetButtonDown ("Fire3") && cooldown <= 1f) {
					if (!hitch) {
						cooldown = 5f;
						Rope.S.objective = projectile.transform.position;
						LineRendererScript.S.destination = projectile.transform;
						Rope.S.moveToRope ();
					} else { 
						Rope.S.objective = cr_objective;
						Rope.S.moveToRope ();
					}
				}
				if(cooldown > 1) {
					gameObject.GetComponent<SpriteRenderer>().color = Color.red;
				}
			}

		}
		this.aiming = Crosshair.S.aiming;
	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag.Equals ("Hitch") ) {
			coll.gameObject.GetComponent<SpriteRenderer>().sprite = hitch_on;
			hitch = true;
			cr_objective = coll.transform.position + new Vector3(0,1f,0);
		}

	}
	

	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.tag.Equals ("Hitch") ) {
			coll.gameObject.GetComponent<SpriteRenderer>().sprite = hitch_off;
		}
		hitch = false;
	}
}
