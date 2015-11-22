using UnityEngine;
using System.Collections;

public class Bed : MonoBehaviour {
    public Sprite[] sprites;
	public AudioClip bedsound;
	SpriteRenderer rend;
    bool done;

    void Start() {
        rend = gameObject.GetComponent<SpriteRenderer>();
        done = false;
        rend.sprite = sprites[0];
    }

    // Use this for initialization
    void Update() {

    }


    void OnTriggerStay2D(Collider2D coll) {
        if (!done && Input.GetButtonDown("Fire1")) {
            done = true;
            CavasFade.S.tent = true;
            rend.sprite = sprites[1];
            Sleep.S.tiredness = 0;
			//SoundManager.S.PlaySound(bedsound);
        }
    }
}