using UnityEngine;
using System.Collections;

public class Rope : MonoBehaviour {
	static public Rope S;
	public Transform objective;

	public int num_ropes = 1;

	void Awake()
	{
		S = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1") && num_ropes>0)
		{
			transform.position = Vector3.Lerp(transform.position, objective.position, 0.5f);
		}
	}
}
