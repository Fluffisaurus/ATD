using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour {

    public static Spawner instance;

    public GameObject gridObj;

    private Tilemap tilemap;
    private Vector3[] spawnArea;
    private int xSize;
    public bool isPlayClicked;
    [HideInInspector]
    public bool isWaveSpawning;

    public WaveBlueprint[] waves;
    public int numEnemiesAlive;
    public static int waveIndex;

    private float[] spawnAmount = { 0, 0, 0 };
    TowerPlacementManager tManager;

	// Use this for initialization
	void Awake () {
        instance = this;
        tManager = TowerPlacementManager.instance;
        tilemap = gridObj.GetComponentInChildren<Tilemap>();
        xSize = tilemap.cellBounds.size.x;
        MakeSpawnArea();
        
        isPlayClicked = false;
        isWaveSpawning = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(numEnemiesAlive > 0) {
            return;
        }
        if (isPlayClicked && !isWaveSpawning) {
            StartCoroutine("SpawnWave");
            return;
        }
	}

    public void SetPlayButton() {
        //make sure there's no leftover enemies
        if (NoEnemiesExists()) {
            isPlayClicked = true;
            tManager.canUserPlace = false;
            tManager.colorPlaceableTiles = false;
        }
        
    }

    public bool NoEnemiesExists() {
        return (FindObjectOfType<Enemy>() == null);
    }

    void MakeSpawnArea() {
        spawnArea = new Vector3[xSize];
        Vector3 origin = tilemap.origin + new Vector3(0.5f, 0, 0) + new Vector3(0, 0.5f, 0);
        for(int x = 0; x < xSize; x++) {
            Vector3 point = origin + Vector3.right * x;
            spawnArea[x] = point;
        }
    }

    IEnumerator SpawnWave() {
        isWaveSpawning = true;

        WaveBlueprint wave = waves[waveIndex];
        spawnAmount[0] = wave.numberOfGenerics;
        spawnAmount[1] = wave.numberOfTanks;
        spawnAmount[2] = wave.numberOfSpeedsters;

        for (int i = 0; i < spawnAmount.Length; i++) {
            SpawnEnemy(wave, spawnAmount[i], i.ToString());
        }
        yield return null;

        //wave gold bonus, scales with difficulty
        PlayerStats.gainWaveGold(2 + 2 * waveIndex);
        isWaveSpawning = false;
        isPlayClicked = false;
        waveIndex++;
        if(waveIndex >= waves.Length && NoEnemiesExists()) {
            //win
            SceneManager.LoadScene("Victory");
            print("you completed this level");
            yield break;
        }
        
    }

    void SpawnEnemy(WaveBlueprint wave, float num, string index) {
        switch (index) {
            case "0":
                for (int i = 0; i < num; i++) {
                    int spawnPos = Random.Range(0, xSize - 1);
                    Instantiate(wave.enemy, spawnArea[spawnPos], Quaternion.identity);
                    numEnemiesAlive++;
                }
                break;
            case "1":
                for (int i = 0; i < num; i++) {
                    int spawnPos = Random.Range(0, xSize - 1);
                    Instantiate(wave.enemyTank, spawnArea[spawnPos], Quaternion.identity);
                    numEnemiesAlive++;
                }
                break;
            case "2":
                for (int i = 0; i < num; i++) {
                    int spawnPos = Random.Range(0, xSize - 1);
                    Instantiate(wave.enemySpeedster, spawnArea[spawnPos], Quaternion.identity);
                    numEnemiesAlive++;
                }
                break;
        }
    }
}
