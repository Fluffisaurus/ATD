using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Enemy : MonoBehaviour {

    public float MAX_HP = 10f;
    private float health;

    public bool stunned { get; set; }
    public bool onFire { get; set; }

    [Header("Unity Enemy Stuff")]
    public Image hpBar;

    private float[] DoT = { 0, 0, 0 };
    private bool isCoroutineRunning;

    private void Start() {
        onFire = false;
        stunned = false;
        health = MAX_HP;
        hpBar.fillAmount = health;
    }

    private void Update() {
        if(health <= 0) {
            print("DEAD: " + gameObject);
            Destroy(gameObject);
        }

        if (onFire && !isCoroutineRunning) {
            StartCoroutine(TakeDamageOverTime(DoT[0], DoT[1], DoT[2]));
        }
    }

    internal void TakeDamage(float dmg) {
        health -= dmg;
        hpBar.fillAmount = health / MAX_HP;
    }

    internal void SetOnFire(float[] DoTValues) {
        for(int i = 0; i < DoT.Length; i++) {
            DoT[i] = DoTValues[i];
        }
    }

    private void ResetOnFire() {
        for (int i = 0; i < DoT.Length; i++) {
            DoT[i] = 0;
        }
    }

    internal IEnumerator TakeDamageOverTime(float dmg, float numOfTicks, float duration) {
        float currTick = 0f;
        isCoroutineRunning = true;
        while(currTick < numOfTicks) {
            health -= dmg;
            hpBar.fillAmount = health / MAX_HP;
            print("DoT ticked for: " + dmg + " damage");
            currTick++;
            yield return new WaitForSecondsRealtime(duration);
        }
        
        onFire = false;
        isCoroutineRunning = false;
        ResetOnFire();
        yield break;
    }

}
