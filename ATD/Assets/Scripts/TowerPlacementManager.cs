using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerPlacementManager : MonoBehaviour {

    public static TowerPlacementManager instance;

    private void Awake() {
        if (instance != null) {
            print("multiple towerplacementmanagers in scene");
            return;
        }
        instance = this;
    }

    [Header("References")]
    public GameObject grid;
    public LayerMask groundMask;
    public LayerMask waterMask;
    public LayerMask unwalkableMask;

    [Header("Debug")]
    public Vector3 mousePos;
    public Vector3Int tilePos;
    public bool showPlaceableGizmos;
    public bool colorPlaceableTiles;
    public bool canUserPlace;
    public bool isFireAnt;

    private BuildManager buildmanager;
    private Tilemap tilemap;
    private List<Vector3> worldListPos;
    private List<Vector3Int> tileListPos;
    private List<Vector3Int> tileListFirePos;

    public GameObject tower;
    Spawner spawner;

	// Use this for initialization
	void Start () {
        spawner = GetComponent<Spawner>();
        buildmanager = BuildManager.instance;
        tilemap = grid.GetComponentInChildren<Tilemap>();
        worldListPos = new List<Vector3>();
        tileListPos = new List<Vector3Int>();
        tileListFirePos = new List<Vector3Int>();
        StartCoroutine("FindPlaceableAreas");
	}
	
    private IEnumerator FindPlaceableAreas() {
        worldListPos.Clear();
        tileListPos.Clear();
        foreach (var pos in tilemap.cellBounds.allPositionsWithin) {
            Vector3Int localPos = new Vector3Int(pos.x, pos.y, pos.z);
            Vector3 place = tilemap.CellToWorld(localPos) + new Vector3(0.5f, 0.5f, 0);
            bool walkableGround = !(Physics2D.OverlapCircle(place, tilemap.cellBounds.size.x / 10 / 2, groundMask));
            bool walkableWater = !(Physics2D.OverlapCircle(place, tilemap.cellBounds.size.x / 10 / 2, waterMask));
            bool walkableStone = !(Physics2D.OverlapCircle(place, tilemap.cellBounds.size.x / 10 / 2, unwalkableMask));
            if (walkableGround && walkableWater && walkableStone) {
                worldListPos.Add(place);
                tileListPos.Add(localPos);
            }
            if (walkableGround && walkableStone) {
                tileListFirePos.Add(localPos);
            }
        }
        yield return null;
    }

	// Update is called once per frame
	void Update () {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        tilePos = tilemap.WorldToCell(mousePos);

        if (Input.GetMouseButtonDown(0) && canUserPlace) {

            if (!buildmanager.CanBuild)
                return;

            if (isFireAnt && tileListFirePos.Contains(tilePos)) {
                buildmanager.BuildTowerHere(tilePos);
            }
            if (tileListPos.Contains(tilePos)) {
                buildmanager.BuildTowerHere(tilePos);
            }
            else {
                print("Can't build at selected location");
            }
            StartCoroutine("FindPlaceableAreas");
        }
        else if(Input.GetMouseButtonDown(0) && !canUserPlace){
            if (!tileListPos.Contains(tilePos)) {
                
            }
            print("hi");
        }

 

        if (colorPlaceableTiles) {
            foreach (var pos in tilemap.cellBounds.allPositionsWithin)
                tilemap.SetColor(pos, Color.white);
            if (isFireAnt) {
                //showing fireants
                foreach (var tile in tileListFirePos) {
                    tilemap.SetColor(tile, Color.green);
                }
            }
            else {
                foreach (var tile in tileListPos)
                    tilemap.SetColor(tile, Color.green);
            }
        }
        else {
            foreach (var tile in tileListPos)
                tilemap.SetColor(tile, Color.white);
        }

	}

    private void OnDrawGizmos() {
        if (showPlaceableGizmos) {
            foreach(var stuff in worldListPos) {
                Gizmos.color = Color.green;
                Gizmos.DrawCube(stuff, Vector3.one * (tilemap.cellBounds.size.x / 10 - .1f));
            }
        }
    }
}
