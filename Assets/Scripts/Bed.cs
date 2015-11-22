using UnityEngine;
using System.Collections;

public class Bed : MonoBehaviour {
    public Sprite[] sprites;
    private SpriteRenderer rend;
    bool done;

    void Start() {
        rend = gameObject.GetComponent<SpriteRenderer>();
        rend.sprite = sprites[0];
        done = false;
    }
	
	// Use this for initialization
	void Update()
	{
        
    }

    void OnTriggerStay2D(Collider2D coll) {
        if (!done && Input.GetButtonDown("Fire1")) {
            CavasFade.S.tent = true;
            //Time.timeScale = 0;
            //Sleep.S.tiredness = 0;
            rend.sprite = sprites[1];
            done = true;
        }
    }
}