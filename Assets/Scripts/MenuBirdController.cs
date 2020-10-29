using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuBirdController : MonoBehaviour {

	public Button button;

	Animator birdFlying;


	void Start () {
		birdFlying = gameObject.GetComponent<Animator> ();
		birdFlying.SetTrigger ("Flap");
		button.onClick.AddListener (TaskOnClick);
	}
		
	void TaskOnClick(){
		SceneManager.LoadScene ("main");
	}

	void FixedUpdate(){
		Debug.Log ("Position "+Mathf.Abs (gameObject.transform.position.y));
		if (Mathf.Abs (gameObject.transform.position.y) < 0.5f) {
			gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2(0, 20f));
		}
	}

}
