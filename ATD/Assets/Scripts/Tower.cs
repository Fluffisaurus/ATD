using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour {

    public GameObject Tower_Range;

    private void OnTriggerEnter(Collider other){
    Debug.Log("Entered Range");
	}
	void Update () {

    }
}
