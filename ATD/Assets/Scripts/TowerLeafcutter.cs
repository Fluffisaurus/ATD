using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLeafcutter : Tower {

	protected override void Start () {
        base.cost = cost;
	}
	
	protected override void Update () {
		//empty
	}

    internal override void UpdateTarget(Collider2D enemy) {
        //empty
    }

    internal override void RemoveTarget(Collider2D enemy) {
        //empty
    }

    protected override void AttackEnemy() {
        //empty
    }
    protected override void OnDrawGizmosSelected() {
        //empty
    }
}
