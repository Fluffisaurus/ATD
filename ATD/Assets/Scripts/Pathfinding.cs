using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;

//referenced from Sebastian Lague's A* Pathfinding and modified for this game's purpose

public class Pathfinding : MonoBehaviour {

    PathRequestManager requestManager;
    GridMap grid; //ref to GridMap.cs

    private void Awake()
    {
        requestManager = GetComponent<PathRequestManager>();
        grid = GetComponent<GridMap>(); //get ref
    }

    public void StartFindPath(Vector3 startPos, Vector3 targetPos) {
        StartCoroutine(FindPath(startPos, targetPos));
    }

    IEnumerator FindPath(Vector3 startPos, Vector3 targetPos)
    {

        Stopwatch sw = new Stopwatch();
        sw.Start();

        Vector3[] waypoints = new Vector3[0];
        bool pathSuccess = false;

        Node startNode = grid.NodeFromWorldPoint(startPos);
        Node targetNode = grid.NodeFromWorldPoint(targetPos);

        if (startNode.walkable && targetNode.walkable) {
            Heap<Node> openNodes = new Heap<Node>(grid.MaxSize);
            HashSet<Node> closedNodes = new HashSet<Node>();

            openNodes.Add(startNode);

            while (openNodes.Count > 0) {
                Node currentNode = openNodes.RemoveFirst();
                closedNodes.Add(currentNode);

                if (currentNode == targetNode) {
                    sw.Stop();
                    //print("Path found: " + sw.ElapsedMilliseconds + " ms");
                    pathSuccess = true;
                    break;
                }

                foreach (Node neighbour in grid.GetNeighbours(currentNode)) {
                    if (!neighbour.walkable || closedNodes.Contains(neighbour))
                        continue;

                    int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
                    if (newMovementCostToNeighbour < neighbour.gCost || !openNodes.Contains(neighbour)) {
                        neighbour.gCost = newMovementCostToNeighbour;
                        neighbour.hCost = GetDistance(neighbour, targetNode);
                        neighbour.parent = currentNode;

                        if (!openNodes.Contains(neighbour))
                            openNodes.Add(neighbour);
                        else
                            openNodes.UpdateItem(neighbour);
                    }
                }
            }
        }
        yield return null;
        if (pathSuccess) {
            waypoints = RetraceOrigin(startNode, targetNode);
        }
        requestManager.FinishedProcessingPath(waypoints, pathSuccess);
    }

    Vector3[] RetraceOrigin(Node startNode, Node targetNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = targetNode;

        while(currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        Vector3[] waypoints = SimplifyPath(path);
        Array.Reverse(waypoints); //flip path
        return waypoints;
    }

    //returns only points in which the path changes or turns
    Vector3[] SimplifyPath(List<Node> path) {
        List<Vector3> waypoints = new List<Vector3>();
        Vector2 directionOld = Vector2.zero;

        for (int i = 1; i < path.Count; i++) {
          //  Vector2 directionNew = new Vector2(path[i - 1].gridX - path[i].gridX, path[i - 1].gridY - path[i].gridY);
            //if (directionNew != directionOld) {
                waypoints.Add(path[i - 1].worldPosition);
            //}
          //  directionOld = directionNew;
            //waypoints.Add(path[i-1].worldPosition);
        }
        return waypoints.ToArray();
    }

    int GetDistance(Node nodeA, Node nodeB)
    {
        int distX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int distY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if(distX > distY)
        {
            return 14 * distY + 10 * (distX - distY);
            //equation takes into account the shortest path including diagonals
            //if each path length = 1, hypotenuse = root(2) = 1.4
            //multiply these values by 10 to get 14 and 10
        }
        else
        {
            return 14 * distX + 10 * (distY - distX);
        }
    }
}
