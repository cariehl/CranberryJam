using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour
{
    public float falling_chance = 0.10f;
    public float speed = 5f;
    public float time = 2f;
    float timer;
    bool falling;
    [HideInInspector] public bool touched;
    bool shake;

	GameObject[] segments;

	GameObject leftSegment = Resources.Load("leftSegment") as GameObject;
	GameObject rightSegment = Resources.Load("rightSegment") as GameObject;
	GameObject middleSegment = Resources.Load("middleSegment") as GameObject;
	GameObject singleSegment = Resources.Load("singleSegment") as GameObject;

	public void Generate(int length)
	{
		segments = new GameObject[length];
		Vector2 genPos = transform.position;
		GameObject segment;
		if (length == 1) {
			segment = Instantiate(singleSegment, genPos, Quaternion.identity) as GameObject;
			segment.transform.parent = this.transform;
			segments[0] = segment;
		} else {
			for (int i = 0; i < length; i++) {
				GameObject toGen = middleSegment;
				if (i == 0)
					toGen = leftSegment;
				else if (i == length - 1)
					toGen = rightSegment;

				segment = Instantiate(toGen, genPos, Quaternion.identity) as GameObject;
				segment.transform.parent = this.transform;
				segments[i] = segment;
				genPos += new Vector2(1, 0);
			}
		}
	}
    
	// Use this for initialization
	void Start () {
        falling = Random.Range(0f, 1f) < falling_chance;
        touched = false;
        timer = 0f;
        shake = false;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(touched);
        if (falling) {
            if (touched) {
                Debug.Log("go");
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
