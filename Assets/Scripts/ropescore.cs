﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ropescore : MonoBehaviour {

    Text txt;

    // Use this for initialization
    void Start() {
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        txt.text = "x " + Rope.S.num_ropes.ToString();
    }
}
