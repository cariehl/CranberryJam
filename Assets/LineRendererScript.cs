using UnityEngine;
using System.Collections;

public class LineRendererScript : MonoBehaviour {
	//Singleton Class
	public static  LineRendererScript S;

	public LineRenderer linerend;
	public float lineDrawSpeed;
	

	public bool ____________________________;

	private float dist;
	private float counter;
	public GameObject origin;
	public Transform destination;
	public bool candraw = false;


	void Awake()
	{
		S = this;
	}


	void Update () {
	//If we can Draw the Rope, Draw it.
	if (candraw) {

		if (counter < (dist)) {
			counter += .1f / lineDrawSpeed;

			float x = Mathf.Lerp (0, dist, counter);

			Vector3 pointA = origin.transform.position;
			Vector3 pointB = destination.position;

			Vector3 pointAlongLine = x * Vector3.Normalize (pointB - pointA) + pointA;
			linerend.SetPosition (1, pointAlongLine);
		}
			else {
				counter =0f;
				linerend.gameObject.SetActive(false);
			}
		}
	}

	public void DrawRope()
	{
		linerend.gameObject.SetActive (true);
		linerend.SetPosition (0, origin.transform.position);
		dist = Vector3.Distance (origin.transform.position, destination.position);
		candraw = true;
	}


}//CLASS
