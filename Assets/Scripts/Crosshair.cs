using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {
	private bool hitch = false;
	public Transform cr_objective ; 
	void Update()
	{
		//position = new Rect((Screen.width - crosshair.width+Input.mousePosition.x) / 2, (Screen.height - crosshair.height - Input.mousePosition.y) /2, crosshair.width, crosshair.height);
		transform.localPosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y) - new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight) / 2;
		if (Input.GetButtonDown("Fire1"))
		{
			if (!hitch) Rope.S.objective = gameObject.transform;
			else Rope.S.objective = cr_objective;
		}

	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag.Equals ("Hitch") ) {
			hitch = true;
			cr_objective = coll.transform;
		}

	}



	void OnTriggerExit2D(Collider2D coll)
	{
		hitch = false;
	}
}
