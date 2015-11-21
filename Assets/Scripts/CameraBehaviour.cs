using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

    GameObject player;
    public float offset = 3;
    float x;
    float z;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        x = transform.position.x;
        z = transform.position.z;
    }
	
	// Update is called once per frame
	void Update () {
        if (player.transform.position.y - transform.position.y > offset) {
            transform.position = new Vector3 (x, (player.transform.position.y - offset), z);
        }
	}
}
