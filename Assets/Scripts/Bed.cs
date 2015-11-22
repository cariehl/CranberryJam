using UnityEngine;
using System.Collections;

public class Bed : MonoBehaviour {
	public Sprite K;
	public Sprite A;
	public Sprite B;
	public Sprite L;
	
	private bool nearbed;
	public SpriteRenderer button;
	public SpriteRenderer button2;
	
	// Use this for initialization
	void Update()
	{
		if (Input.GetButtonDown ("Fire1")&&nearbed) {
			Debug.Log ("Slept On the Tent");
			Sleep.S.tiredness = 0;
		}
		if (Input.GetButtonDown ("Fire2")&&nearbed){
			Debug.Log ("Pillaged The Tent");
            DontDestroy.S.score += 100;
		}
	}


	void OnTriggerEnter2D(Collider2D coll)
	{
		Debug.Log ("Collided");
		nearbed = true;
		if (coll.gameObject.tag.Equals ("Player")) {
			if(xboxCont())
			{ 
				button.sprite = A;
				button2.sprite = B;
			}
			else 
			{
				button.sprite = L;
				button2.sprite = K;
			}
		}
	}
	
	public bool xboxCont()
	{
		
		if (Input.GetJoystickNames ().Length > 0) {
			return true;
		}
		return false;
	}


	void OnTriggerExit2D(Collider2D coll)
	{
		nearbed = false;
		button.sprite = null;
		button2.sprite = null;
	}
}