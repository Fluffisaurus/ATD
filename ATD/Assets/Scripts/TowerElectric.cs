using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerElectric : Tower {

    public float stunDuration;

	// Use this for initialization
	protected override void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	protected override void Update () {
        base.Update();
	}

    protected override void AttackEnemy() {
        GameObject bulletFired = (GameObject)Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        BulletElectric bullet = bulletFired.GetComponent<BulletElectric>();
        if (bullet != null) {
            bullet.Seek(target, stunDuration);
        }
    }

    protected override void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, rangeGizmo);
    }
}
