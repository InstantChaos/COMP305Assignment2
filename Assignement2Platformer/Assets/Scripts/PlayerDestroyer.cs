//Source File: PlayerDestroyer
//Author: Franco Chong
//Date Modified: October 25, 2015
//Program Description: Destroys the player and restarts the scene


using UnityEngine;
using System.Collections;

public class PlayerDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//reloads the scene upon collision with the player.
	void OnTriggerEnter2D(Collider2D otherCollider){
		
		if (otherCollider.gameObject.CompareTag("Player")){
			Application.LoadLevel(Application.loadedLevel);
		}
		
	}
}
