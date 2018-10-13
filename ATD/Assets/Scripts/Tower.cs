using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tower : MonoBehaviour {

    public Transform target;
    public float rangeGizmo = 2f;
    public float attackDelay = 1f;
    public float damage = 1f;
    public float cost = 10f;

    private float nextDmgEvent;
    private GameObject child;
    private CircleCollider2D range;

    protected virtual void Start() {
        child = this.transform.GetChild(0).gameObject;
        range = child.GetComponent<CircleCollider2D>();
        range.radius = rangeGizmo * 0.917f / 2.75f;
        target = null;
    }

    internal virtual void UpdateTarget(Collider2D enemy) {
        if (target == null) {
            target = enemy.transform;
            //print("TARGET: " + target.gameObject);
        }
    }

    internal virtual void RemoveTarget(Collider2D enemy) {
        if (target == enemy.transform) {
            target = null;
            //print("TARGET: null");
        }
    }

    protected virtual void AttackEnemy() {
        target.GetComponent<Enemy>().TakeDamage(damage);
        print("attack");
    }

    protected virtual void Update() {
        if(target != null) {
            if (Time.time >= nextDmgEvent) {
                nextDmgEvent = Time.time + attackDelay;
                if (target.gameObject.tag == "Enemy") {
                    AttackEnemy();
                }
            }

        }
        else {
            nextDmgEvent = Time.time + attackDelay;
        }
    }

    protected virtual void OnDrawGizmosSelected() {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, rangeGizmo);
    }
}
