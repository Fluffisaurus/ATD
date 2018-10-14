using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusUI : MonoBehaviour {

    public Text hp;
    public Text money;
	
	void Update () {
        hp.text = "HP: " + PlayerStats.Health;
        money.text = "Honey: " + PlayerStats.Honey;
	}
}
