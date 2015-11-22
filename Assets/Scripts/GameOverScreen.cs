using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour {
    

	// Use this for initialization
	void Start () {
        
    }

	public void Restart()
	{
		Application.LoadLevel("GameScene");
	}

    public void MainMenu() {
        Application.LoadLevel("MainMenu");
    }

    // Update is called once per frame
    void Update () {
	
	}
}
