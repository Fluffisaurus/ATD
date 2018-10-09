﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridMap : MonoBehaviour {

    public GameObject gridObj;
    public Transform enemy;
    
    private Tilemap tilemap;
    private BoundsInt bounds;
    private int xBound, yBound;
    public LayerMask unwalkableMask;
    Node[,] gridStuff;

    private void Start()
    {
        tilemap = gridObj.GetComponentInChildren<Tilemap>();
        bounds = tilemap.cellBounds;
        xBound = bounds.size.x;
        yBound = bounds.size.y;
        //Debug.Log(bounds.size.x);
        //Debug.Log(bounds.size.y);
        MakeNodeGrid(); //create reference grid of type Node
    }

    private void Update()
    {
        
    }

    void MakeNodeGrid()
    {
        gridStuff = new Node[xBound, yBound];
        Vector3 origin = tilemap.origin + new Vector3(0.5f, 0, 0) + new Vector3(0, 0.5f, 0); //gets bottom left corner
        //Vector3 origin = tilemap.origin; //gets bottom left corner
        //Debug.Log(origin);
        for (int x = 0; x < xBound; x++)
        {
            for(int y = 0; y < yBound; y++)
            {
                //retrieve position of each grid point 
                Vector3 gridPoint = origin + Vector3.right * x + Vector3.up * y;
                //overlapcircle checks if there's any colliders at the current circular location
                bool walkable = !(Physics2D.OverlapCircle(gridPoint, bounds.size.x/10/2, unwalkableMask));
                gridStuff[x, y] = new Node(walkable, gridPoint);
                //Debug.Log(gridPoint);
            }
        }
    }

    public Node NodeFromWorldPoint(Vector3 worldPos)
    {
        float percentX = (worldPos.x + bounds.size.x / 2) / bounds.size.x;
        float percentY = (worldPos.y + bounds.size.y / 2) / bounds.size.y;

        int x = Mathf.RoundToInt(bounds.size.x  * percentX);
        int y = Mathf.FloorToInt(bounds.size.y  * percentY);
        Debug.Log("Supposed Point: " + x + ", " + y);
        return gridStuff[x, y-1];
    }

    private void OnDrawGizmos()
    {

        //check if nodegrid is actually registering new grid points
        if (gridStuff != null)
        {
            Node enemyNode = NodeFromWorldPoint(enemy.position);
            //Debug.Log(enemy.position);
            foreach (Node n in gridStuff)
            {
                Gizmos.color = (n.walkable) ? Color.white : Color.red;
                if(enemyNode == n)
                {
                    Gizmos.color = Color.cyan;
                }
                Gizmos.DrawCube(n.worldPosition, Vector3.one * (bounds.size.x/10 - .1f));
                //Debug.Log("drawing cube part " + n);
            }
        }
        //else
        //{
        //    Debug.Log("gridstuff is null");
        //}
    }
}