using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    private void Awake() {
        if (instance != null) {
            print("multiple buildmanagers in scene");
            return;
        }
        instance = this;
    }

    public GameObject towerPrefab;

    private void Start() {
        towerToBuild = towerPrefab;
    }

    private GameObject towerToBuild;

    public GameObject GetTowerToBuild() {
        return towerToBuild;
    }

}
