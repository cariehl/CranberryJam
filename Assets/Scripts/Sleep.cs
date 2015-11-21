using UnityEngine;
using System.Collections;

public class Sleep : MonoBehaviour {
	static public Sleep S;

	void Awake()
	{
		S = this;
	}

	public int sleepTick;
	public int tiredness = 0;
	public int score = 0;
	
	private int counter =1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if ((counter % sleepTick) == 0) {
			tiredness++;
			score++;
			counter=1;
		}
	if (tiredness == 100) {
			Debug.Log ("You fell asleep");
			Destroy(gameObject);
		}
	counter++;

	}

}
