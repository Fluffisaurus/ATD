using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletElectric : Bullet {

    private float dur;
    //overload
    public void Seek(Transform target, float dur) {
        base.target = target;
        this.dur = dur;
    }

    protected override void HitTarget() {
        bool currentlyStunned = target.GetComponent<Enemy>().stunned;
        if (!currentlyStunned) {
            target.GetComponent<Enemy>().SetStun(dur);
        }
        Destroy(gameObject);
    }

}
