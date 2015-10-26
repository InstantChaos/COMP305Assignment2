//Source File: PlayerController
//Author: Franco Chong
//Date Modified: October 21, 2015
//Program Description: Lets the player control the movement of the character.

using UnityEngine;
using System.Collections;

//public classes that can be reused.
[System.Serializable]
public class VelocityRange
{
	public float vMin, vMax;
	
	public VelocityRange (float vMin, float vMax)
	{
		this.vMin = vMin;
		this.vMax = vMax;
	}
}

public class PlayerController : MonoBehaviour
{
	
	//public variables 
	public float speed = 20f;
	public float jump = 200f;
	public VelocityRange velocityRange = new VelocityRange (300f, 500f);
	
	//private variables
	private Rigidbody2D rigid;
	private Animator animator;
	private Transform trans;
	//creates an array of audiosources
	private AudioSource[] myAudioSources;
	private AudioSource itempickup;
	private AudioSource zombierawr;
	private AudioSource flag;
	
	
	//sets the value to check if the player is moving.
	private float moveVal = 0;
	//checks if the player is facing right.
	private bool facingright = true;
	//checks if the player is on the ground.
	private bool grounded = true;
	
	// Use this for initialization
	void Start ()
	{
		this.rigid = gameObject.GetComponent<Rigidbody2D> ();
		this.trans = gameObject.GetComponent<Transform> ();
		this.animator = gameObject.GetComponent<Animator> ();

		this.myAudioSources = gameObject.GetComponents<AudioSource> ();
		this.itempickup = this.myAudioSources [0];
		this.zombierawr = this.myAudioSources [1];
		this.flag = this.myAudioSources [2];
		
		
	}
	
	void FixedUpdate ()
	{
		
		//variables to set the position of the forces
		float forceX = 0f;
		float forceY = 0f;
		//sets the velocity with an absolute value.
		float velX = Mathf.Abs (this.rigid.velocity.x);
		float velY = Mathf.Abs (this.rigid.velocity.y);
		
		
		this.moveVal = Input.GetAxis ("Horizontal");
		
		//checks if the player is moving
		if (this.moveVal != 0) { 
			//check if player is on the ground
			if (this.grounded) {
				this.animator.SetInteger ("AnimState", 1);
				if (this.moveVal > 0) {
					// moves the player to the right
					if (velX < this.velocityRange.vMax) {
						forceX = this.speed;
						this.facingright = true;
						this.flip ();
					}
				} else if (this.moveVal < 0) {
					// moves the player to the left
					if (velX < this.velocityRange.vMax) {
						forceX = -this.speed;
						this.facingright = false;
						this.flip ();
					}
				}
			}
			
			
		} else {
			// plays the player's idle animation.
			this.animator.SetInteger ("AnimState", 0);
		}
		
		// check if player is jumping using the WASD keys on the keyboard
		if ((Input.GetKey (KeyCode.W))) {
			// checks if the player is on the ground
			if (this.grounded) {
				//plays the player's jump animation.
				this.animator.SetInteger ("AnimState", 2);
				if (velY < this.velocityRange.vMax) {
					forceY = this.jump;
					this.grounded = false;
				}
			}
		}
		
		// pushes the player with the force variables set above.
		this.rigid.AddForce (new Vector2 (forceX, forceY));
	}

	//checks if the player lands an the ground called platform
	void OnCollisionStay2D (Collision2D other)
	{
		if (other.gameObject.CompareTag ("Platform")) {
			this.grounded = true;
		}
		
	}

	//plays the itempickup sound when the player collides with the item
	void OnCollisionEnter2D(Collision2D othercollider){
		if (othercollider.gameObject.CompareTag ("MedPack")) {
			this.itempickup.Play();
		}

		if (othercollider.gameObject.CompareTag ("Enemy")) {
			this.zombierawr.Play();
		}

		if (othercollider.gameObject.CompareTag ("EndFlag")) {
			this.flag.Play();
		}
	}
	
	// private methods
	//flips the player's sprite to face the other side when a value either -1 or 1.
	private void flip ()
	{
		if (this.facingright) {
			this.trans.localScale = new Vector3 (3f, 3f, 1f);
		} else {
			this.trans.localScale = new Vector3 (-3f, 3f, 1f);
		}
	}
	
}
