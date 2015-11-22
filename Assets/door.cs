using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerStay2D(Collider2D coll) {
        if (Input.GetButtonDown("Fire1")) {
            //CavasFade.S.tent = true;
            Application.LoadLevel(0);
        }
    }
}
