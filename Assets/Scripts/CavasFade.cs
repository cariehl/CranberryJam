using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CavasFade : MonoBehaviour {

    Image img;
    float alpha;
    float ratio;

    // Use this for initialization
    void Start () {
        img = GetComponent<Image>();
        ratio = Sleep.S.time / 0.7f;
	}
	
	// Update is called once per frame
	void Update () {
        alpha = Sleep.S.tiredness / ratio;
        img.color = new Color(0f, 0f, 0f, alpha);
	}
}
