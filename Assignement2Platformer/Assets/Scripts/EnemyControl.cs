//Source File: EnemyControl
//Author: Franco Chong
//Date Modified: October 25, 2015
//Program Description: Computer Controls the enemy to move on a platform.


using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {

	//public variables
	public float speed = 100f;

	//enemy's line of sight
	public Transform sightStart;
	public Transform sightEnd;
	
	//private variables

	//checks if the enemy is on the ground
	private bool ground = false;
	private bool moreground = true;
	private Rigidbody2D rigidbody;
	private Transform trans;
	private Animator anim;
	
	
	// Use this for initialization
	void Start () {
		this.rigidbody = gameObject.GetComponent<Rigidbody2D> ();
		this.trans = gameObject.GetComponent<Transform> ();
		this.anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//check if enemy is on the ground
		if (this.ground) {
			//plays the walking animation
			this.anim.SetInteger ("AnimState", 1);
			this.rigidbody.velocity = new Vector2(this.trans.localScale.x, 0) * this.speed;

			//draws the enemy's line of sight
			this.moreground = Physics2D.Linecast(this.sightStart.position,this.sightEnd.position, 1 << LayerMask.NameToLayer("Solid"));
			Debug.DrawLine(this.sightStart.position, this.sightEnd.position);

			//if theres no more ground, flip the enemy
			if(this.moreground == false){
				this.fliptheenemy();
			}
			
		} else {
			this.anim.SetInteger ("AnimState", 0);
		}
	}

	//checks if the player collided with the circle collider.
	void OnTriggerEnter2D(CircleCollider2D otherCollider){
		if (otherCollider.gameObject.CompareTag ("Player")) {
			Destroy(gameObject);
		}
	}

	//checks if the enemy is on the ground.
	void OnCollisionStay2D(Collision2D otherCollider) {
		if (otherCollider.gameObject.CompareTag ("Platform")) {
			this.ground =  true;
		}
	}

	//checks if theres no more ground.
	void OnCollisionExit2D(Collision2D otherCollider) {
		if (otherCollider.gameObject.CompareTag ("Platform")) {
			this.ground =  false;
		}
	}

	//flips the enemy if theres no more ground.
	private void fliptheenemy() {
		if (this.trans.localScale.x == 1) {
			this.trans.localScale = new Vector3(-1f, 1f, 1f); 
		} else {
			this.trans.localScale = new Vector3(1f, 1f, 1f);
		}
	}
}
