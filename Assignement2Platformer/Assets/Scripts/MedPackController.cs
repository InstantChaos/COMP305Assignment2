//Source File: MedPackController
//Author: Franco Chong
//Date Modified: October 25, 2015
//Program Description: Destroys the medpack gameobject if it collides with the player

using UnityEngine;
using System.Collections;

public class MedPackController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Destroys the medpack if it collides with the player.
	void OnTriggerEnter2D(Collider2D otherCollider){

		if (otherCollider.gameObject.CompareTag("Player")){
			Destroy(gameObject);
		}
			
	}
}
