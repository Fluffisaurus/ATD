using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour {

    public float health = 10f;

    private void Update() {
        if(health <= 0) {
            print("dead");
            Destroy(gameObject);
        }
    }

    internal void TakeDamage(float value) {
        health -= value;
    }
}
