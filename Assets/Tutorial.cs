using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        Sleep.S.tiredness = 0;
    }


	void OnTriggerStay2D(Collider2D coll) {
        Debug.Log("intent");
        if (coll.gameObject.tag.Equals("Player")) {
            if (Input.GetButtonDown("Fire1")) {
                Debug.Log("go");
                Application.LoadLevel("MainMenu");
            }
        }
    }
}
