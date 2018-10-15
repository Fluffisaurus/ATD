using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBarUI : MonoBehaviour {

    public GameObject stun;
    public GameObject fire;

	// Use this for initialization
	void Start () {
 
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.GetComponentInParent<Enemy>().stunned) stun.SetActive(true);
        else stun.SetActive(false);

        if (gameObject.GetComponentInParent<Enemy>().onFire) fire.SetActive(true);
        else fire.SetActive(false);
	}
}
