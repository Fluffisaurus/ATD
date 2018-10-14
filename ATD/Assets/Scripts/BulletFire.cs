using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : Bullet {

    private float[] dmg;
    //overload
	public void Seek(Transform target, float[] dmg) {
        base.target = target;
        this.dmg = dmg;
    }

    protected override void HitTarget() {
        bool isOnFire = target.GetComponent<Enemy>().onFire;
        if (!isOnFire) {
            target.GetComponent<Enemy>().SetOnFire(dmg);
        }
        Destroy(gameObject);
    }
}
