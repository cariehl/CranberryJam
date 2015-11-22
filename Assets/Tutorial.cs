using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

    bool sleep;
    bool done;

	// Use this for initialization
	void Start () {
        sleep = false;
        done = false;
	}

    // Update is called once per frame
    void Update() {
        if (!sleep)
            Sleep.S.tiredness = 0;
    }


	void OnTriggerEnter2D(Collider2D coll) {
        //Debug.Log("intent");
        if (coll.gameObject.tag.Equals("Player")) {
            sleep = true;
            if (!done) {
                Sleep.S.tiredness = Sleep.S.time * 0.2f;
                done = true;
            }
        }
    }
}
