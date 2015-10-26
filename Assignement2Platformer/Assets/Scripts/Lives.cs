//Source File: Lives
//Author: Franco Chong
//Date Modified: October 25, 2015
//Program Description: Calculates the lives.


using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Lives : MonoBehaviour {

	public Text livesLabel;
	public int livescount = 5;
	
	public Text GOLabel;
	
	
	// Use this for initialization
	void Start () {
		
		//calls the setLives method to set the total number of lives
		this.setLives ();
		
		//turns off the gameover text until conditions are met
		this.GOLabel.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//set the number of lives available for the player.
	private void setLives(){
		this.livesLabel.text = "Lives: " + this.livescount;
	}
	
	//Lives will be deducted upon sensing a collision.
	void OnTriggerEnter2D(Collider2D otherObjects){
		if (otherObjects.tag == "Enemy") {
			this.livescount -= 1;
			Destroy(otherObjects.gameObject);
		}
		//Destroys the player and display game over text when player's lives reach 0.
		if(this.livescount <=0){
			this.GOLabel.enabled = true;
			Destroy(gameObject);
			
		}
		this.setLives ();		
	}
}
