using UnityEngine;
using System.Collections;

public class Sleep : MonoBehaviour {
	public int sleepTick;
	public int tiredness = 0;

	private int counter =0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if ((counter % sleepTick) == 0) {
			tiredness++;
			counter=0;
		}
	if (tiredness == 100) {
			Debug.Log ("You fell asleep");
			Destroy(gameObject);
		}
	counter++;

	}
}
