using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Loadlvl(){
		//Debug.Log ("Loading my scene");
		Application.LoadLevel("GameScene");
	}
    public void Loadtut() {
        //Debug.Log("Loading my scene");
        Application.LoadLevel("Tutorial");
    }
}
