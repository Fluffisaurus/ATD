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
        bool currentlyStunned = target.GetComponent<Enemy>().stunned;
        if (!currentlyStunned) {
            target.GetComponent<Enemy>().SetStun(stunDuration);
        }
    }

    protected override void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, rangeGizmo);
    }
}
