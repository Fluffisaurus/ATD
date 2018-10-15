using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {

    public static int Health;
    public int startingHealth = 100;

    public static int Honey;
    public int startingHoney = 50;

    public static float honeyMultiplier;

    // Use this for initialization  private void Start() {
    void Start () {
        if(Difficulty.difficulty[0] == true) {
            Health = startingHealth;
            Honey = startingHoney;
            honeyMultiplier = 1;
        }else if(Difficulty.difficulty[1] == true) {
            Health = Mathf.RoundToInt(startingHealth * 0.8f);
            Honey = Mathf.RoundToInt(startingHoney * 0.8f);
            honeyMultiplier = 1.2f;
        }else if(Difficulty.difficulty[2] == true) {
            Health = Mathf.RoundToInt(startingHealth * 0.6f);
            Honey = Mathf.RoundToInt(startingHoney * 0.6f);
            honeyMultiplier = 1.5f;
        }
        else {//easy by default if someone nothing works or accessing directly from mainscene
            Health = startingHealth;
            Honey = startingHoney;
            honeyMultiplier = 1;
        }

        //reset selection
        for (int i = 0; i < Difficulty.difficulty.Length; i++) Difficulty.difficulty[i] = false;
    }

    public void FixedUpdate() {
        if(Health <= 0) {
            SceneManager.LoadScene("Game_Over");
        }
    }

    public void LoseHP(int value) {
        Health -= value;
    }

    public static void gainWaveGold(int value) {
        Honey += Mathf.FloorToInt(value * honeyMultiplier);
    }

    public static void gainEnemyGold(int value) {
        Honey += Mathf.FloorToInt(value * honeyMultiplier);
    }

}
