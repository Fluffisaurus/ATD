using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node{
    public bool walkable;
    public Vector3 worldPosition;
    public int gridX;
    public int gridY;

    public int gCost; //distance from starting node
    public int hCost; //heuristic cost or distance from end node
    public Node parent;

    public Node(bool isWalkable, Vector3 worldPos, int gridPosX, int gridPosY)
    {
        walkable = isWalkable;
        worldPosition = worldPos;
        //Debug.Log("new Node being made");
        gridX = gridPosX;
        gridY = gridPosY;
    }

    public int fCost //total cost
    {
        get
        {
            return gCost + hCost;
        }
    }
}
