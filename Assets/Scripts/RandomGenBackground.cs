using UnityEngine;
using System.Collections;

public class RandomGenBackground : MonoBehaviour
{
	// List of tiles and their weighted random chances
	public GameObject[] tiles;
	public int[] tileWeights;

	// Minimum x point to start generating tiles
	int minX;
	// Current highest y level of tiles
	int currentMaxY;

	// Number of tiles to exist in horizontal and vertical directions
	const int tilesWide = 6;
	const int tilesHigh = 6;

	// Creates a new row of random tiles at position y
	void MakeNewRow(int height)
	{
		// Make a tile at each X point from left to right
		for (int i = minX; i < minX + tilesWide; i++)
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
			newTile.transform.parent = this.transform;
		}
	}

	void DeleteRow(int height)
	{
		for (int i = minX; i < minX + tilesWide; i++)
		{

		}
	}

	// Use this for initialization
	void Start ()
	{
		minX = (int)Camera.main.transform.position.x - 3;
		int y = (int)Camera.main.transform.position.y - 3;
		for (int i = y; i <= y + tilesHigh; i++)
		{
			MakeNewRow(i);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		int currentY = (int)Camera.main.transform.position.y - 3 + tilesHigh;
		if (currentY > currentMaxY)
		{
			currentMaxY = currentY;
			MakeNewRow(currentMaxY);
		}
	}
}
