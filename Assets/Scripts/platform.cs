using UnityEngine;
using System.Collections;

public class platform : MonoBehaviour {

	public bool canBeHazard = true;
    public float falling_chance = 0.10f;
    public float speed = .1f;
    public float time = 1f;
    float timer;
    bool falling;
    [HideInInspector] public bool touched;
    bool shake;
    private SpriteRenderer[] sprites;
    
	// Use this for initialization
	void Start () {
        falling_chance = 0.10f;
        speed = .1f;
        time = 1f;
		if (canBeHazard) {
			falling = Random.Range(0f, 1f) < falling_chance;
		}
        if (falling) {
            sprites = GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer sprite in sprites) {
                sprite.color = new Color(1.0f, 0.45f, 0.45f, 1.0f);
            }
        }
		touched = false;
        timer = 0f;
        shake = false;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(touched);
        if (falling) {
            if (touched) {
                //Debug.Log("go");
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
