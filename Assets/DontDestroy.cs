using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {

    public float score;
    static public DontDestroy S;


    void Awake() {
        S = this;
        DontDestroyOnLoad(transform.gameObject);
    }
}
