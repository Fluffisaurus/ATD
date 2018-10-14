using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Spawner : MonoBehaviour {

    public GameObject gridObj;
    [Header("Enemies")]
    public Transform enemy;
    public Transform enemyTank;
    public Transform enemySpeedster;
    [Header("Number of each enemy")]
    public float numberOfGenerics;
    public float numberOfTanks;
    public float numberOfSpeedsters;

    private Tilemap tilemap;
    private Vector3[] spawnArea;
    private int xSize;

    private float[] spawnAmount = { 0, 0, 0 };

	// Use this for initialization
	void Start () {
        tilemap = gridObj.GetComponentInChildren<Tilemap>();
        xSize = tilemap.cellBounds.size.x;
        MakeSpawnArea();
        SetSpawnAmount();
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

    void SetSpawnAmount() {
        spawnAmount[0] = numberOfGenerics;
        spawnAmount[1] = numberOfTanks;
        spawnAmount[2] = numberOfSpeedsters;
    }

    void SpawnWave() {
        for(int i = 0; i < spawnAmount.Length; i++) {
            SpawnEnemy(spawnAmount[i], i.ToString());
        }
    }

    void SpawnEnemy(float num, string index) {
        switch (index) {
            case "0":
                for (int i = 0; i < num; i++) {
                    int spawnPos = Random.Range(0, xSize - 1);
                    Instantiate(enemy, spawnArea[spawnPos], Quaternion.identity);
                }
                break;
            case "1":
                for (int i = 0; i < num; i++) {
                    int spawnPos = Random.Range(0, xSize - 1);
                    Instantiate(enemyTank, spawnArea[spawnPos], Quaternion.identity);
                }
                break;
            case "2":
                for (int i = 0; i < num; i++) {
                    int spawnPos = Random.Range(0, xSize - 1);
                    Instantiate(enemySpeedster, spawnArea[spawnPos], Quaternion.identity);
                }
                break;
        }
    }
}
