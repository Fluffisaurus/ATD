using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public static int currentLevel = 1;

	public void Back(){
		SceneManager.LoadScene("Title_Page");
	}
	public void Lvl1(){
        currentLevel = 1;
		SceneManager.LoadScene("Difficulty_Select");
	}

}
