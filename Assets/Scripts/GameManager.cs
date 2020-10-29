using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Obstacle obstacle;

	public int myScore;
	public Text myScoreGUI;
	public Text highScore;
	//public Image gameOver;
	public Button button;
	public GameObject gameOverMenu;
	public Transform topObstacle, bottomObstacle;
	public AudioSource audioSource;


	void Start () {
		
		myScore = 0;
		InvokeRepeating ("ObstacleSpawner", 0.2f, 1.5f);
		button.onClick.AddListener (TaskOnClick);
		gameOverMenu.SetActive (false);
		//obstacle =  GameObject.Find ("Obstacle").GetComponent<Obstacle> ();
	}

	public void GmAddScore(){
		this.myScore++;
		obstacle.IncreaseSpeed ();
		myScoreGUI.text = myScore.ToString ();
		audioSource.Play ();
	}

	void ObstacleSpawner(){
		int rand = Random.Range (0,2);
		float topObstacleMinY = 2.8f, topObstacleMaxY = 5.5f, bottomObstacleMinY = -5f, bottomObstacleMaxY = -2.77f;

		switch(rand){

			case 0 :
			Instantiate(bottomObstacle,new Vector2(9f,Random.Range(bottomObstacleMinY,bottomObstacleMaxY)),Quaternion.identity);
				break;

			case 1 :
			Instantiate(topObstacle,new Vector2(9f,Random.Range(topObstacleMinY,topObstacleMaxY)),topObstacle.rotation);
				break;
		}
	}

	public void UpdateHighScore(){

		//Debug.Log ("highScore = "+PlayerPrefs.GetInt("highScore"));
		if (myScore > PlayerPrefs.GetInt("highScore")) {
			
			PlayerPrefs.SetInt("highScore",myScore);
		}

		string score = "High Score : "+PlayerPrefs.GetInt ("highScore");
		Debug.Log (score);
		highScore.text = score;
	}

	void TaskOnClick(){
		SceneManager.LoadScene ("main");
	}
		

	public void EnableGameOver(){
		gameOverMenu.SetActive (true);
		UpdateHighScore ();
	}
}
