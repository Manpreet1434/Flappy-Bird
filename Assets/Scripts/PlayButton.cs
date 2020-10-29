using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayButton : MonoBehaviour {

	void Play(){
		SceneManager.LoadScene ("main");
	}
}
