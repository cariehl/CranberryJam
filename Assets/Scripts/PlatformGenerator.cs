using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour
{
	// Minimum number of templates to keep generated at any one time
	public int minNumTemplatesOnScreen;

	// Beds are generated in the range:
	// [minDistanceBetweenBeds, minDistanceBetweenBeds + bedDistanceVariance]
	// Minimum number of templates to generate before generating a bed template
	public int minDistanceBetweenBeds;
	// Range of templates in which a bed can be generated
	public int bedDistanceVariance;

	private int bedDistanceCounter = 0;
	private int bedDistanceNext = 0;

	// Array of all possible templates to generate
	// Templates must have complete PlatformTemplateData scripts
	public GameObject[] platformTemplates;
	public GameObject[] bedTemplates;

	int lowestPlatformNum = 0;	// Determines the next template to destroy
	int nextPlatformNum = 0;	// Determines the number of the next generated template
	int screenLowStart = 0;		// Lowest y-coord of the screen at the start of the game
	int currentGeneratedHeight = 0;	// Highest unit of platform we have generated so far
	int screenHeight = 0;		// Height of the screen, used to determine when to generate another platform

	// Create a new instance of the template at the given index in our array
	// If index is not specified, picks a random index
	void MakeNewPlatform(int index = -1)
	{
		PlatformTemplateData data;
		GameObject nextTemplate;

		// Bed template override
		bedDistanceCounter++;
		if (bedDistanceCounter >= bedDistanceNext && index == -1) {
			bedDistanceCounter = 0;
			bedDistanceNext = minDistanceBetweenBeds + Random.Range(0, bedDistanceVariance + 1);
			nextTemplate = bedTemplates[Random.Range(0, bedTemplates.Length)];
            data = nextTemplate.GetComponent<PlatformTemplateData>();
		} else {
			if (index == -1)
				index = Random.Range(0, platformTemplates.Length);
			nextTemplate = platformTemplates[index];
			data = nextTemplate.GetComponent<PlatformTemplateData>();
		}
		// Instantiate our new platform template
		GameObject platform = Instantiate(
			nextTemplate,
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
		bedDistanceNext = minDistanceBetweenBeds + Random.Range(0, bedDistanceVariance + 1);
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
			MakeNewPlatform();
		}
    }
}
