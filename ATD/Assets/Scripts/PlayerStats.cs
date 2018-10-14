using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int Health;
    public int startingHealth = 100;

    public static int Honey;
    public int startingHoney = 50;

    // Use this for initialization
    void Start () {

        if(Difficulty.difficulty[0] == true) {
            Health = startingHealth;
            Honey = startingHoney;
        }else if(Difficulty.difficulty[1] == true) {
            Health = Mathf.RoundToInt(startingHealth * 0.8f);
            Honey = Mathf.RoundToInt(startingHoney * 0.8f);
        }else if(Difficulty.difficulty[2] == true) {
            Health = Mathf.RoundToInt(startingHealth * 0.6f);
            Honey = Mathf.RoundToInt(startingHoney * 0.6f);
        }
        else {//easy by default if someone nothing works or accessing directly from mainscene
            Health = startingHealth;
            Honey = startingHoney;
        }

        //reset selection
        for (int i = 0; i < Difficulty.difficulty.Length; i++) Difficulty.difficulty[i] = false;
    }
	
    public void LoseHP(int value) {
        Health -= value;
    }
}
