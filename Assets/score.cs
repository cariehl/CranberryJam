using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class score : MonoBehaviour {

    Text txt;

	// Use this for initialization
	void Start () {
        txt = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        txt.text = "Score: " + Mathf.FloorToInt(Sleep.S.score).ToString() + "\nRopes: " + Rope.S.num_ropes.ToString();
	}
}
