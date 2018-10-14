using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	public void Back(){
		SceneManager.LoadScene("Title_Page");
	}
	public void Lvl1(){
		SceneManager.LoadScene("Dificulty_Select");
	}

}
