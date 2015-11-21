using UnityEngine;
using System.Collections;

public class platformseg : MonoBehaviour {

    platform plat;

	// Use this for initialization
	void Start () {
        plat = GetComponentInParent<platform>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Player") {
           // Debug.Log("huh?");
            if (coll.enabled) {
                
                plat.touched = true;
            }
        }
    }
}
