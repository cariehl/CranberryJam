using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayHighScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = "HIGH SCORE" + "\n" + "Name: " + PlayerPrefs.GetString("highscoreName", "Goat") + "\n" + "Score: " + PlayerPrefs.GetInt("highscore", 0);
    }
}
