using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CavasFade : MonoBehaviour {
    static public CavasFade S;

    void Awake() {
        S = this;
    }

    Image img;
    float alpha;
    float ratio;
    [HideInInspector] public bool alive;

    // Use this for initialization
    void Start () {
        img = GetComponent<Image>();
        ratio = Sleep.S.time / 0.9f;
        alive = true;
	}
	
	// Update is called once per frame
	void Update () {
//        Debug.Log(alpha);
        if (alive) {
            alpha = Sleep.S.tiredness / ratio;
        }
        else {
            alpha += alpha / 100;
            if (alpha >= 1) {
                if (DontDestroy.S.score > PlayerPrefs.GetInt("highscore")) {
                    Application.LoadLevel("HighScore");
                } else {
                    Application.LoadLevel("GameOver");
                }
            }
        }
        img.color = new Color(0f, 0f, 0f, alpha);
	}
}
