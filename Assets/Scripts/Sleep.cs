using UnityEngine;
using System.Collections;

public class Sleep : MonoBehaviour {
	static public Sleep S;

	void Awake()
	{
		S = this;
	}

    public float time;
    //private float timer;
	//public int sleepTick;
	[HideInInspector] public float tiredness = 0;
    [HideInInspector] public float score = 0;
	
	private int counter =1;

	// Use this for initialization
	void Start () {
        tiredness = 0;
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	/*if ((counter % sleepTick) == 0) {
			tiredness++;
			score++;
			counter=1;
		}
	if (tiredness < time) {
			Debug.Log ("You fell asleep");
            Application.LoadLevel("GameOver");
		}
	counter++;
    */
        if (tiredness > time) {
            Application.LoadLevel("GameOver");
        }
        tiredness += Time.deltaTime;
        score += Time.deltaTime;
	}

}
