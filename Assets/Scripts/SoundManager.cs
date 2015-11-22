using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	//Singleton Class
	public static SoundManager S;
	public AudioListener audiolist;
	public AudioSource Sfx;

	void Awake(){
		S = this;
		}

	void Start(){
		Sfx = Camera.main.gameObject.GetComponent<AudioSource> ();
		audiolist = Camera.main.gameObject.GetComponent<AudioListener> ();
	}

	public void PlaySound(AudioClip clip)
	{
		Sfx.clip = clip;
		Sfx.Play ();
	}
	

}
