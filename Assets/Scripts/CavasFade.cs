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
    [HideInInspector] public bool tent;
    bool black;

    // Use this for initialization
    void Start () {
        img = GetComponent<Image>();
        ratio = Sleep.S.time / (0.9f - 0.1f);
        alive = true;
        black = true;
        tent = false;
	}
	
	// Update is called once per frame
	void Update () {
       
        if (tent) {
            //Debug.Log("go");
            if (black) {
                img.color = Color.Lerp(img.color, Color.black, 8f * Time.deltaTime);
                if (img.color.a > 0.95)
                    black = false;
            } else {
                img.color = Color.Lerp(img.color, Color.clear, 8f * Time.deltaTime);
                if (img.color.a < 0.05) {
                    black = true;
                    tent = false;
                    //PlayerMovement.S.can_move = true;
                }
            }
        } else {
            if (alive) {
               // Debug.Log(Sleep.S.tiredness);
                alpha = (Sleep.S.tiredness) / ratio + 0.1f;
            } else {
                //Debug.Log("dead");
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
}
