using UnityEngine;
using System.Collections;

public class RandomGenBackground : MonoBehaviour
{
	// Number of extra tiles to generate in the X and Y directions
	public int tileOffsetX;
	public int tileOffsetY;
	// List of tiles and their weighted random chances
	public GameObject[] tiles;
	public int[] tileWeights;
	
	int startX = 0;		// x-coord to start making tiles per row
	int endX = 0;       // x-coord to end making tiles per row
	int lowestTileRow = 0;

	// Current highest y level of tiles
	int screenTopMax;

	// Creates a new row of random tiles at position y
	void MakeNewRow(int height)
	{
		GameObject rowContainer = new GameObject("Row" + height);
		rowContainer.transform.parent = this.transform;
		// Make a tile at each X point from left to right
		for (int i = startX; i < endX; i++)
		{
			GameObject tileToMake = tiles[0];
			int rand = Random.Range(0, 100);
			// Compare our random number to the weighted chance of each tile
			for (int j = 0; j < tiles.Length; j++)
			{
				if (rand < tileWeights[j])
				{
					tileToMake = tiles[j];
					break;
				}
				// If we didnt find the right tile, subtract that tile's
				// weighted random change from our random number
				rand -= tileWeights[j];
			}

			GameObject newTile = Instantiate(tileToMake, new Vector3(i, height), Quaternion.identity) as GameObject;
			newTile.transform.parent = rowContainer.transform;
		}
	}

	// Use this for initialization
	void Start ()
	{
		Vector2 botLeftScreen = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, Camera.main.nearClipPlane));
		Vector2 topRightScreen = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, Camera.main.nearClipPlane));

		screenTopMax = Mathf.RoundToInt(topRightScreen.y) + tileOffsetY;
		startX = Mathf.RoundToInt(botLeftScreen.x) - tileOffsetX;
		endX = Mathf.RoundToInt(topRightScreen.x) + tileOffsetX;
		lowestTileRow = Mathf.RoundToInt(botLeftScreen.y) - tileOffsetY;

		for (int i = lowestTileRow; i <= Mathf.RoundToInt(topRightScreen.y) + tileOffsetY; i++)
		{
			MakeNewRow(i);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		int screenTopCurrent = Mathf.RoundToInt(Camera.main.ViewportToWorldPoint(new Vector3(0f, 1f)).y) + tileOffsetY;
		if (screenTopCurrent > screenTopMax)
		{
			screenTopMax = screenTopCurrent;
			MakeNewRow(screenTopMax);
			Destroy(GameObject.Find("Row" + lowestTileRow));
			lowestTileRow++;
		}
	}
}
