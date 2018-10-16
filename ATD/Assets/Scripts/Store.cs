using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour {

    public TowerBlueprint bullet;
    public TowerBlueprint fire;
    public TowerBlueprint electric;
    public TowerBlueprint leafcutter;

    BuildManager buildManager;
    TowerPlacementManager tManager;
    Spawner spawner;

    private void Start() {
        spawner = Spawner.instance;
        buildManager = BuildManager.instance;
        tManager = TowerPlacementManager.instance;
    }

    public void SelectLeafcutterAnt() {
        if (spawner.numEnemiesAlive == 0) {
            print("Leafcutter Ant Selected");
            buildManager.SelectTowerToBuild(leafcutter);
            tManager.canUserPlace = (tManager.canUserPlace) ? false : true;
            tManager.colorPlaceableTiles = (tManager.colorPlaceableTiles) ? false : true;
            tManager.isFireAnt = false;
        }
    }

    public void SelectBulletAnt() {
        if (spawner.numEnemiesAlive == 0) {
            print("Bullet Ant Selected");
            buildManager.SelectTowerToBuild(bullet);
            tManager.canUserPlace = (tManager.canUserPlace) ? false : true;
            tManager.colorPlaceableTiles = (tManager.colorPlaceableTiles) ? false : true;
            tManager.isFireAnt = false;
        }
    }

    public void SelectFireAnt() {
        if (spawner.numEnemiesAlive == 0) {
            print("Fire Ant Selected");
            buildManager.SelectTowerToBuild(fire);
            tManager.canUserPlace = (tManager.canUserPlace) ? false : true;
            tManager.colorPlaceableTiles = (tManager.colorPlaceableTiles) ? false : true;
            tManager.isFireAnt = true;
        }
    }

    public void SelectElectricAnt() {
        if (spawner.numEnemiesAlive == 0) {
            print("Electric Ant Selected");
            buildManager.SelectTowerToBuild(electric);
            tManager.canUserPlace = (tManager.canUserPlace) ? false : true;
            tManager.colorPlaceableTiles = (tManager.colorPlaceableTiles) ? false : true;
            tManager.isFireAnt = false;
        }
    }
}
