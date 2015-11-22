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
        //Debug.Log(tiredness);
        if (tiredness > time) {
            //Debug.Log(time);
            //Debug.Log(tiredness);
            CavasFade.S.alive = false;
        }
        tiredness += Time.deltaTime;
        DontDestroy.S.score += 10f * Time.deltaTime;
	}

}
