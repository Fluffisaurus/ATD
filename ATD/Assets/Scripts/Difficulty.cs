using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour {
	public static bool [] difficulty = {false, false, false};

	public void Easy(){
		difficulty[0] = true;
		SceneManager.LoadScene("MainScene");

	}
	public void Medium(){
		difficulty[1] = true;

		SceneManager.LoadScene("MainScene");

	}
	public void Hard(){
		difficulty[2] = true;
		SceneManager.LoadScene("MainScene");
	}
}
