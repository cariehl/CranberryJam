using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {
	//Singleton Class
	static public Crosshair S;

	public GameObject projectile;
	public Sprite target;
	public float ropeCooldown = 1f;

	public bool ___________________;


	public Vector3 cr_objective ;
	public bool aiming;

	private float cooldown;
	private bool hitch = false;
	private Camera cam;
	private Vector3 mousePos2D;

	void Awake(){
		S = this;
	}

	void Start(){
		cam = Camera.main;
	}


	void Update()
	{
		cooldown -= Time.deltaTime;
		if(cooldown <= 1) gameObject.GetComponent<SpriteRenderer>().color = Color.green;

		if (!aiming) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = null;
		}
		else { //if (aiming)
			gameObject.GetComponent<SpriteRenderer> ().sprite = target;
			mousePos2D = Input.mousePosition;
			mousePos2D.z = -Camera.main.transform.position.z;
			Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);
			Vector3 mouseDelta = mousePos3D - Rope.S.transform.position;
			float maxMagnitude = Rope.S.radius;
			if (mouseDelta.magnitude > maxMagnitude) {
				mouseDelta.Normalize ();
				mouseDelta *= maxMagnitude;
			}
			Vector3 projPos = Rope.S.transform.position + mouseDelta;
			projectile.transform.position = projPos;

			if (Rope.S.num_ropes > 0) {
				if (Input.GetButtonDown ("Fire3") && cooldown <= 1f) {
					cooldown = ropeCooldown;
					Rope.S.objective = projectile.transform.position + Vector3.up*2;
					LineRendererScript.S.destination = projectile.transform;
					Rope.S.moveToRope ();
					Rope.S.num_ropes--;
				}
				if(cooldown > 1) {
					gameObject.GetComponent<SpriteRenderer>().color = Color.red;
				}
			}
			else {
				gameObject.GetComponent<SpriteRenderer> ().color = Color.gray;
			}
		}
		this.aiming = Crosshair.S.aiming;
	}

	/*LEGACY CODE  -- HITCHES
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag.Equals ("Hitch") ) {
			//coll.gameObject.GetComponent<SpriteRenderer>().sprite = hitch_on;
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
	}*/
}