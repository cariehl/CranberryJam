using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameoverScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = "Final Score: " + Mathf.FloorToInt(DontDestroy.S.score);
        //DontDestroy.S.score = 0;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
