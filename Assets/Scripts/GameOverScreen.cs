using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void Restart()
	{
		Application.LoadLevel("MainMenu");
	}

    public void MainMenu() {
        Application.LoadLevel("MainMenu");
    }

    // Update is called once per frame
    void Update () {
	
	}
}
