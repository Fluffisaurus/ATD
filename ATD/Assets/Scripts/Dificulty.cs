using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dificulty : MonoBehaviour {
	public bool [] dificulty = {false, false, false};

	public void easy(){
		dificulty[0] = true;
		SceneManager.LoadScene("MainScene");

	}
	public void medium(){
		dificulty[1] = true;

		SceneManager.LoadScene("MainScene");

	}
	public void hard(){
		dificulty[2] = true;
		SceneManager.LoadScene("MainScene");
	}
}
