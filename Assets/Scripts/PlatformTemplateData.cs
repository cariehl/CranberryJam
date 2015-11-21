using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlatformData
{
	public int x;
	public int y;
	public int length;
}

public class PlatformTemplateData : MonoBehaviour
{
	// Height of this template, in units
	public int height;

	// Width of this template, in units
	public int width;

	// Starting position offset of this template, from the coordinate (0,0)
	public int offsetX;
	public int offsetY;

	// Array of Platform Data
	public PlatformData[] platforms;
}
