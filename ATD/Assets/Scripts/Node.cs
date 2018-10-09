using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node{
    public bool walkable;
    public Vector2 worldPosition;

    public Node(bool isWalkable, Vector3 worldPos)
    {
        walkable = isWalkable;
        worldPosition = worldPos;
        Debug.Log("new Node being made");
    }
}
