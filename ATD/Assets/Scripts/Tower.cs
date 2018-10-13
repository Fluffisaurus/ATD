using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tower : MonoBehaviour {

    public Transform target;
    public float rangeGizmo = 2f;

    private GameObject child;
    private CircleCollider2D range;

    void Start() {
        child = this.transform.GetChild(0).gameObject;
        range = child.GetComponent<CircleCollider2D>();
        range.radius = rangeGizmo * 0.917f / 2.75f;
        target = null;
    }

    internal void UpdateTarget(Collider2D enemy) {
        if (target == null) {
            target = enemy.transform;
            print("target set to: " + target);
        }
    }

    internal void RemoveTarget(Collider2D enemy) {
        if (target == enemy.transform) {
            target = null;
            print("unassigned " + enemy.transform + " as target");
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeGizmo);
    }
}
