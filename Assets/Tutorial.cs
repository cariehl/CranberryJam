using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

    bool sleep;

	// Use this for initialization
	void Start () {
        sleep = false;
	}

    // Update is called once per frame
    void Update() {
        if (!sleep)
            Sleep.S.tiredness = 0;
    }


	void OnTriggerEnter2D(Collider2D coll) {
        Debug.Log("intent");
        if (coll.gameObject.tag.Equals("Player")) {
            sleep = true;
            Sleep.S.tiredness += 20;
        }
    }
}
