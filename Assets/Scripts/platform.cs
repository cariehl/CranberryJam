﻿using UnityEngine;
using System.Collections;

public class platform : MonoBehaviour {

    public float falling_chance = 0.10f;
    public float speed = .1f;
    public float time = 1f;
    float timer;
    bool falling;
    [HideInInspector] public bool touched;
    bool shake;
    
	// Use this for initialization
	void Start () {
        falling = Random.Range(0f, 1f) < falling_chance;
        touched = false;
        timer = 0f;
        shake = false;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(touched);
        if (falling) {
            if (touched) {
                Debug.Log("go");
                timer += Time.deltaTime;
                if (shake) {
                    transform.position += Vector3.right * 0.2f;
                    shake = false;
                } else {
                    transform.position += Vector3.left * 0.2f;
                    shake = true;
                }
            }
        }
        if (timer > time) {
            transform.position += Vector3.down * speed;
        }
	}

}