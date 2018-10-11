using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Spawner : MonoBehaviour {

    public Transform enemy;
    public GameObject gridObj;

    private Tilemap tilemap;
    private Grid spawnArea;

	// Use this for initialization
	void Start () {
        tilemap = gridObj.GetComponentInChildren<Tilemap>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
