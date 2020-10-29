using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdController : MonoBehaviour {



	private Rigidbody2D myRigidBody;
	private Animator myAnimator;
	private float jumpforce;

	public bool isAlive;
	public AudioSource flyAudio,deathAudio;
	public Image ready;
	public GameManager gameManager;

	void Start () {
		
		isAlive = true;
		myRigidBody = gameObject.GetComponent<Rigidbody2D> ();
		myAnimator = gameObject.GetComponent<Animator> ();
		jumpforce = 10f;
		myRigidBody.gravityScale = 5f;
		Time.timeScale = 0;

	}
		
	void Update () {
		if (isAlive) 
		{
			if (Input.GetMouseButton (0)) 
			{
				if (Time.timeScale == 0) 
				{
					ready.enabled = false;
					Time.timeScale = 1;
				}
				Flap ();
			}
			CheckIfBirdHitBounds ();
		} 
		else 
		{
			//StartCoroutine ("DisableImage");
			gameManager.EnableGameOver();

		}
	}
		

	void Flap(){

		myRigidBody.velocity = new Vector2 (0, jumpforce);
		myAnimator.SetTrigger ("Flap");
		flyAudio.Play ();
	}

	void OnCollisionEnter2D(Collision2D target){

		if (target.gameObject.tag == "Obstacle") {
			isAlive = false;
			Time.timeScale = 0f;
			deathAudio.Play ();
			//gameOver.enabled = true;
		}
	}

	void CheckIfBirdHitBounds(){
		if (Mathf.Abs (gameObject.transform.position.y) > 4.66f || Mathf.Abs (gameObject.transform.position.y) < -4.63f) {
			isAlive = false;
			Time.timeScale = 0f;
			deathAudio.Play ();
			//gameOver.enabled = true;
		}
	}
}
