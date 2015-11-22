using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Loadlvl() {
        PlayerPrefs.DeleteKey("highscore");
        PlayerPrefs.DeleteKey("highscorename");
        Application.LoadLevel("GameScene");
	}
}
