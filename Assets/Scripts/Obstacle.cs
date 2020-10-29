using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	public GameObject Bird;

	Rigidbody2D myRigidBody;
	float birdXPosition;
	bool isScoreAdded;
	public float speed;
	GameManager gameManager;

	// Use this for initialization
	void Start () {
		speed = -2.5f;

		AddVelocity ();

		birdXPosition = Bird.transform.position.x;

		isScoreAdded = false;

		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < birdXPosition) {
			if (!isScoreAdded) {
				AddScore ();
				isScoreAdded = true;
			}
		}

		if (transform.position.x <= -10f) {
			Destroy (gameObject);
		}
	}


	void AddScore(){
		gameManager.GmAddScore ();
	}
		
	void AddVelocity(){
		Debug.Log ("Speed= "+speed);
		myRigidBody = gameObject.GetComponent<Rigidbody2D> ();
		myRigidBody.velocity = new Vector2 (speed, 0);
	}

	public void IncreaseSpeed(){
		speed = speed - 0.1f;
	}
}
