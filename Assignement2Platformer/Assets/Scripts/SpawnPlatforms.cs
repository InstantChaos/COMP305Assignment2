//Source File: SpawnPlatforms
//Author: Franco Chong
//Date Modified: October 22, 2015
//Program Description: Spawns platforms across the game scene.

using UnityEngine;
using System.Collections;

public class SpawnPlatforms : MonoBehaviour {

	//public variables

	//spawns the amount of platforms at a time.
	public int platformspawned = 10;
	//allows the game to spawn a platform away from the player at a specified location.
	public float minHorizontal = 5f;
	public float maxHorizontal = 10f;
	public float minVertical = -5f;
	public float maxVertical = 5f;

	public GameObject platform;

	//private variables

	//sets the position for the first platform
	private Vector2 oPosition;

	// Use this for initialization
	void Start () {

		//gets the value of the first platform
		oPosition = transform.position;
		Spawningtheplatforms ();
	
	}

	//method to spawn the platforms randomly within a set value
	void Spawningtheplatforms(){
		for (int i = 0; i < platformspawned; i++)
		{
			Vector2 random = oPosition + new Vector2 (Random.Range(minHorizontal, maxHorizontal), Random.Range (minVertical, maxVertical));
			Instantiate(platform, random, Quaternion.identity);
			oPosition = random;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
