using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HIGH : MonoBehaviour {

    string playername;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Name(InputField IF) {
        playername = IF.text;
    }

    public void Loadlvl() {
        PlayerPrefs.SetInt("highscore", Mathf.FloorToInt(DontDestroy.S.score));
        PlayerPrefs.SetString("highscoreName", playername);
        Application.LoadLevel("GameOver");
    }
}
