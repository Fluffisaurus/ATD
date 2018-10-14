using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {
	public void Title(){
		SceneManager.LoadScene("Title_Page");
	}

	public void Level(){
		SceneManager.LoadScene("Level_Select");
	}
}
