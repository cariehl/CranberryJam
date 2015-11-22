using UnityEngine;
using System.Collections;

public class Sleep : MonoBehaviour {
	static public Sleep S;

	void Awake()
	{
		S = this;
	}

    public float time;
	[HideInInspector] public float tiredness = 0;
    //[HideInInspector] public float score = 0;

	// Use this for initialization
	void Start () {
        tiredness = 0;
        DontDestroy.S.score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (tiredness > time) {
            if (DontDestroy.S.score > PlayerPrefs.GetInt("highscore")) {
                Application.LoadLevel("HighScore");
            }
            else
                Application.LoadLevel("GameOver");
        }
        tiredness += Time.deltaTime;
        DontDestroy.S.score += Time.deltaTime;
	}

}
