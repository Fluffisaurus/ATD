using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory_UI : MonoBehaviour {

	public void Victory_retry(){
		SceneManager.LoadScene("Difficulty_Select");
	}
	public void Victory_Quit(){
		Application.Quit();
	}

}
