using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Spawner : MonoBehaviour {

    public Transform enemy;
    public GameObject gridObj;

    private Tilemap tilemap;
    private Vector3[] spawnArea;
    private int xSize, ySize;

	// Use this for initialization
	void Start () {
        tilemap = gridObj.GetComponentInChildren<Tilemap>();
        xSize = tilemap.cellBounds.size.x;
        ySize = tilemap.cellBounds.size.y / 10;
        MakeSpawnArea();
        SpawnWave();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void MakeSpawnArea() {
        spawnArea = new Vector3[xSize];
        Vector3 origin = tilemap.origin + new Vector3(0.5f, 0, 0) + new Vector3(0, 0.5f, 0);
        for(int x = 0; x < xSize; x++) {
            Vector3 point = origin + Vector3.right * x;
            spawnArea[x] = point;
        }
    }

    void SpawnWave() {
        for(int i = 0; i < 5; i++) {
            int spawnPos = Random.Range(0, xSize - 1);
            Instantiate(enemy, spawnArea[spawnPos], Quaternion.identity);
        }
    }
}
