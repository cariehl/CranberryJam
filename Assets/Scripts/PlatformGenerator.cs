using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour
{
	// Minimum number of templates to keep generated at any one time
	public int minNumTemplatesOnScreen;
	// Array of all possible templates to generate
	// Templates must have complete PlatformTemplateData scripts
	public GameObject[] platformTemplates;

	int lowestPlatformNum = 0;	// Determines the next template to destroy
	int nextPlatformNum = 0;	// Determines the number of the next generated template
	int screenLowStart = 0;		// Lowest y-coord of the screen at the start of the game
	int currentGeneratedHeight = 0;	// Highest unit of platform we have generated so far
	int screenHeight = 0;		// Height of the screen, used to determine when to generate another platform

	// Create a new instance of the template at the given index in our array
	void MakeNewPlatform(int index)
	{
		PlatformTemplateData data = platformTemplates[index].GetComponent<PlatformTemplateData>();
		// Instantiate our new platform template
		GameObject platform = Instantiate(
			platformTemplates[index],
			new Vector3(data.offsetX, currentGeneratedHeight + data.offsetY, 0),
			Quaternion.identity
		) as GameObject;
		// Name the template so we can delete it later
		platform.name = "Template" + nextPlatformNum;
		// Increment our height and template number
		currentGeneratedHeight += data.height;
		nextPlatformNum++;

		// We only want to keep three templates at a time
		if (nextPlatformNum > lowestPlatformNum + minNumTemplatesOnScreen) {
			Destroy(GameObject.Find("Template" + lowestPlatformNum));
			lowestPlatformNum++;
		}
    }

	// Use this for initialization
	void Start ()
	{
		screenLowStart = Mathf.RoundToInt(Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f)).y);
		screenHeight = Mathf.RoundToInt(Camera.main.ViewportToWorldPoint(new Vector3(0f, 1f)).y - screenLowStart);
		// First template in the list is always the first one generated,
		// for consistency in testing
		MakeNewPlatform(0);
	}

	// Update is called once per frame
	void Update ()
	{
		int screenTop = Mathf.RoundToInt(Camera.main.ViewportToWorldPoint(new Vector3(0f, 1f)).y) - screenLowStart;
		// We want to always have at least 1 screen's worth of extra platforms
		if (screenTop >= (currentGeneratedHeight - screenHeight)) {
			// Generate a randomly-selected platform template
			int randIndex = Random.Range(0, platformTemplates.Length);
			MakeNewPlatform(randIndex);
		}
    }
}
