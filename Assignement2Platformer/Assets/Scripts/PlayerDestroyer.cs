using UnityEngine;
using System.Collections;

public class PlayerDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D otherCollider){
		
		if (otherCollider.gameObject.CompareTag("Player")){
			Application.LoadLevel(Application.loadedLevel);
		}
		
	}
}
