using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameoverScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (DontDestroy.S.score > PlayerPrefs.GetInt("highscore")) {
            PlayerPrefs.SetInt("highscore", Mathf.FloorToInt(DontDestroy.S.score));
            GetComponent<Text>().text = "High Score!" + "\n" + "Final Score: " + DontDestroy.S.score;
        }
        else
            GetComponent<Text>().text = "Final Score: " + DontDestroy.S.score;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
