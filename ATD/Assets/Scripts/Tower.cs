using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tower : MonoBehaviour {

    public Transform target;

    [Header("Stats")]
    public float rangeGizmo = 2f;
    public float attackSpeed = 1f;
    public float attackCooldown = 0f;
    public int damage = 1;
    public float cost = 10f;

    public GameObject bulletPrefab;
    public Transform firePos;

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
        //target.GetComponent<Enemy>().TakeDamage(damage);
        GameObject bulletFired = (GameObject)Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        Bullet bullet = bulletFired.GetComponent<Bullet>();
        if(bullet != null) {
            bullet.Seek(target, damage);
        }
        //print("attack");
    }

    protected virtual void Update() {
        if(target != null && target.gameObject.tag == "Enemy") {
            if(attackCooldown <= 0f) {
                AttackEnemy();
                attackCooldown = 1f / attackSpeed;
            }
            attackCooldown -= Time.deltaTime;
        }
    }

    protected virtual void OnDrawGizmosSelected() {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, rangeGizmo);
    }
}
