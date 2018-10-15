using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet : MonoBehaviour {

    protected Transform target;
    protected int dmg;
    public float speed = 3f;

    public void Seek(Transform target, int dmg) {
        this.target = target;
        this.dmg = dmg;
    }

    protected void Update() {
        if(target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if(dir.magnitude <= distanceThisFrame) {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.right = target.position - transform.position;
    }

    protected virtual void HitTarget() {
        target.gameObject.GetComponent<Enemy>().TakeDamage(dmg);
        Destroy(gameObject);
    }
}
