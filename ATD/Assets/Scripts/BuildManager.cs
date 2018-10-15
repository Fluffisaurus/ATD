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
    public GameObject towerFirePrefab;
    public GameObject towerElectricPrefab;
    public GameObject towerLeafcutterPrefab;

    public TowerBlueprint towerToBuild { get; set; }
    private GameObject selectedTower;

    public bool CanBuild { get { return towerToBuild != null; } }

    public void BuildTowerHere(Vector3Int pos) {
        if(PlayerStats.Honey < towerToBuild.cost) {
            print("Not enough honey to build " + towerToBuild.prefab);
            return;
        }

        PlayerStats.Honey -= towerToBuild.cost;

        GameObject tower = Instantiate(towerToBuild.prefab, pos + new Vector3(0.5f, 0.5f, 0), Quaternion.identity);

        print("Purchased: " + towerToBuild.prefab);
    }

    public void SelectTower(GameObject tower) {
        selectedTower = tower;
        towerToBuild = null;
    }

    public void SelectTowerToBuild(TowerBlueprint tower) {
        towerToBuild = tower;
        selectedTower = null;
    }
}
