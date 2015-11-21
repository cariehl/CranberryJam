using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {
	private bool hitch = false;
	public Vector3 cr_objective ;
	public GameObject projectile;
	Camera cam;

	//Get the current mouse position in 2d Screen coords
	Vector3 mousePos2D;



	void Start(){
		cam = Camera.main;

	}
	void Update()
	{
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
		if (Rope.S.num_ropes>0){
			if (Input.GetButtonDown("Fire1") ){
				if (!hitch){
					Rope.S.objective =  cr_objective;
					Rope.S.moveToRope();
				}
				else{ 
					Rope.S.objective = cr_objective;
					Rope.S.moveToRope();
				}
			}
		}
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
