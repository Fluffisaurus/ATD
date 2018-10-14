using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour {

    public TowerBlueprint bullet;
    public TowerBlueprint fire;
    public TowerBlueprint electric;
    public TowerBlueprint leafcutter;

    public GameObject obj;
    BuildManager buildManager;
    TowerPlacementManager tManager;

    private Spawner spawner;

    private void Start() {
        spawner = obj.GetComponent<Spawner>();
        buildManager = BuildManager.instance;
        tManager = obj.GetComponent<TowerPlacementManager>();
    }

    public void SelectLeafcutterAnt() {
        if (spawner.CheckIfNoEnemiesExists()) {
            print("Leafcutter Ant Selected");
            buildManager.SelectTowerToBuild(leafcutter);
            tManager.canUserPlace = (tManager.canUserPlace) ? false : true;
            tManager.colorPlaceableTiles = (tManager.colorPlaceableTiles) ? false : true;
        }
    }

    public void SelectBulletAnt() {
        if (spawner.CheckIfNoEnemiesExists()) {
            print("Bullet Ant Selected");
            buildManager.SelectTowerToBuild(bullet);
            tManager.canUserPlace = (tManager.canUserPlace) ? false : true;
            tManager.colorPlaceableTiles = (tManager.colorPlaceableTiles) ? false : true;
        }
    }

    public void SelectFireAnt() {
        if (spawner.CheckIfNoEnemiesExists()) {
            print("Fire Ant Selected");
            buildManager.SelectTowerToBuild(fire);
            tManager.canUserPlace = (tManager.canUserPlace) ? false : true;
            tManager.colorPlaceableTiles = (tManager.colorPlaceableTiles) ? false : true;
        }
    }

    public void SelectElectricAnt() {
        if (spawner.CheckIfNoEnemiesExists()) {
            print("Electric Ant Selected");
            buildManager.SelectTowerToBuild(electric);
            tManager.canUserPlace = (tManager.canUserPlace) ? false : true;
            tManager.colorPlaceableTiles = (tManager.colorPlaceableTiles) ? false : true;
        }
    }
}
