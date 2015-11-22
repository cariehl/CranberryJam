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
        Application.LoadLevel("GameScene");
	}

    public void tutorial() {
        Application.LoadLevel("Tutorial");
    }

    public void Reset() {
        PlayerPrefs.DeleteKey("highscore");
        PlayerPrefs.DeleteKey("highscoreName");
    }
}
