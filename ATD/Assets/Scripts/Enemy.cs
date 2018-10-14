using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Enemy : MonoBehaviour {

    public float MAX_HP = 10f;
    private float health;
    public int damageToPlayer;
    public int honeyGained;

    public bool stunned { get; set; }
    public bool onFire { get; set; }

    [Header("Unity Enemy Stuff")]
    public Image hpBar;

    private float[] DoT = { 0, 0, 0 };
    private bool isDOTCoroutineRunning;
    private float stunDuration;
    private bool isStunCoroutineRunning;

    private void Start() {
        onFire = false;
        stunned = false;
        health = MAX_HP;
        hpBar.fillAmount = health;
    }

    private void Update() {
        if(health <= 0) {
            Dead();
        }

        if (onFire && !isDOTCoroutineRunning) {
            StartCoroutine(TakeDamageOverTime(DoT[0], DoT[1], DoT[2]));
        }

        if(stunned && !isStunCoroutineRunning) {
            StartCoroutine(IsStunned(stunDuration));
        }
    }

    internal void Dead() {
        print("DEAD: " + gameObject);
        PlayerStats.Honey += honeyGained;
        Destroy(gameObject);
    }

    internal void TakeDamage(float dmg) {
        health -= dmg;
        hpBar.fillAmount = health / MAX_HP;
    }

    internal void SetOnFire(float[] DoTValues) {
        onFire = true;
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
        isDOTCoroutineRunning = true;
        while(currTick < numOfTicks) {
            health -= dmg;
            hpBar.fillAmount = health / MAX_HP;
            print("DoT ticked for: " + dmg + " damage");
            currTick++;
            yield return new WaitForSecondsRealtime(duration);
        }
        
        onFire = false;
        isDOTCoroutineRunning = false;
        ResetOnFire();
        yield break;
    }

    internal void SetStun(float duration) {
        stunned = true;
        stunDuration = duration;
    }

    internal IEnumerator IsStunned(float duration) {
        isStunCoroutineRunning = true;
        print("stunned for: " + duration);
        yield return new WaitForSecondsRealtime(duration);

        stunned = false;
        isStunCoroutineRunning = false;
        yield break;
    }

}
