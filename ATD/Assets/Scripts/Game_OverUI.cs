using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_OverUI : MonoBehaviour {

	public void lose_restart(){
		SceneManager.LoadScene("MainScene");
	}
	public void lose_back(){
		SceneManager.LoadScene("Level_Select");
	}

}
