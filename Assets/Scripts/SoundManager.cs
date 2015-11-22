using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	//Singleton Class
	public static SoundManager S;
	public AudioListener audiolist;

	public AudioSource[] tracks;
	void Awake(){
		S = this;
		tracks = new AudioSource[]{};
	}

	void Start(){
		audiolist = gameObject.GetComponent<AudioListener> ();
	}

	public void PlaySound()
	{

	}

}
