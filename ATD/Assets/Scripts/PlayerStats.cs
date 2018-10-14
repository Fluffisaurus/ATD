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
        Health = startingHealth;
        Honey = startingHoney;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoseHP(int value) {
        Health -= value;
    }
}
