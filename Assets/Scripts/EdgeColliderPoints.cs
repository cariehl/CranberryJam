using UnityEngine;
using System.Collections;

public class EdgeColliderPoints : MonoBehaviour
{
	public Vector2[] vertices;
	EdgeCollider2D coll;

	// Use this for initialization
	void Start ()
	{
		coll = GetComponent<EdgeCollider2D>();
		coll.points = vertices;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
