using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRange : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Enemy") {
            //print("hi, enter");
            gameObject.GetComponentInParent<Tower>().UpdateTarget(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Enemy") {
            //print("hi, exit");
            gameObject.GetComponentInParent<Tower>().RemoveTarget(collision);
        }
    }
}
