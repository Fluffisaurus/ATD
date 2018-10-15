using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TowerFire : Tower {

    public float numberOfTicks = 2;
    public float damageInterval = 2;

    protected override void Start() {
        base.Start();
        base.cost = cost;
    }

    protected override void Update() {
        base.Update();
    }

    protected override void AttackEnemy() {
        GameObject bulletFired = (GameObject)Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        BulletFire bullet = bulletFired.GetComponent<BulletFire>();
        if (bullet != null) {
            float[] DoTStats = { base.damage, numberOfTicks, damageInterval };
            bullet.Seek(target, DoTStats);
        }
    }

    protected override void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeGizmo);
    }

}
