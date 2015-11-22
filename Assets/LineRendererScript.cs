using UnityEngine;
using System.Collections;

public class LineRendererScript : MonoBehaviour {
	public static  LineRendererScript S;
	public Transform origin;
	public Transform destination;

	private float dist;
	public LineRenderer linerend;
	private float counter;

	public float lineDrawSpeed;

	public bool candraw = false;
	void Awake()
	{
		S = this;
	}
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		if (candraw) {
			if (counter < dist) {
				counter += .1f / lineDrawSpeed;

				float x = Mathf.Lerp (0, dist, counter);

				Vector3 pointA = origin.position;
				Vector3 pointB = destination.position;

				Vector3 pointAlongLine = x * Vector3.Normalize (pointB - pointA) + pointA;
				linerend.SetPosition (1, pointAlongLine);
			}

		}
	}

	public void DrawRope()
	{
		linerend.SetPosition (0, origin.position);
		dist = Vector3.Distance (origin.position, destination.position);
		candraw = true;
	}




}
