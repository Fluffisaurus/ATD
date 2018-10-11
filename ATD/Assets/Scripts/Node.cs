using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : IHeapItem<Node>{
    public bool walkable;
    public Vector3 worldPosition;
    public int gridX;
    public int gridY;

    public int gCost; //distance from starting node
    public int hCost; //heuristic cost or distance from end node
    public Node parent;
    int heapIndex;

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

    public int HeapIndex {
        get {
            return heapIndex;
        }
        set {
            heapIndex = value;
        }
    }

    public int CompareTo(Node nodeToCompare) {
        int compare = fCost.CompareTo(nodeToCompare.fCost);
        if(compare == 0) {//fCosts are equal, compare hCost
            compare = hCost.CompareTo(nodeToCompare.hCost);
            //compareTo will return 1 if its higher, 
            //but we want the lower hCost so return -compare
        }
        return -compare;
    }
}
