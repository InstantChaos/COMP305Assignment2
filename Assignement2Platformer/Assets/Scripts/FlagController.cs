//Source File: Flag Controller
//Author: Franco Chong
//Date Modified: October 25, 2015
//Program Description: Displays the win sign.


using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FlagController : MonoBehaviour {

	//public variables
	public Text winLabel;


	// Use this for initialization
	void Start () {

		//turns off the win text until conditions are met
		this.winLabel.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Destroys the flag if it collides with the player.
	void OnTriggerEnter2D(Collider2D otherCollider){
		
		if (otherCollider.gameObject.CompareTag("Player")){
			this.winLabel.enabled = true;
			Destroy(gameObject);
		}
		
	}
}
