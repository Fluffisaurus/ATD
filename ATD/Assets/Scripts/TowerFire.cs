using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TowerFire : Tower {

    public float numberOfTicks = 2;
    public float damageInterval = 2;

    protected override void Start() {
        base.Start();
    }

    protected override void Update() {
        base.Update();
    }

    protected override void AttackEnemy() {
        bool isOnFire = target.GetComponent<Enemy>().onFire;
        if (!isOnFire) {
            float[] DoTStats = { base.damage, numberOfTicks, damageInterval };
            target.GetComponent<Enemy>().onFire = true;
            target.GetComponent<Enemy>().SetOnFire(DoTStats);
        }
    }

    protected override void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeGizmo);
    }

}
