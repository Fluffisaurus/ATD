using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour {
	public void Play(){
		SceneManager.LoadScene("Level_Select");
	}
	public void Quit(){
		Application.Quit();
	}
}
