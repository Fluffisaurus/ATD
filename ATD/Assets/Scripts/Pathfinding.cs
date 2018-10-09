using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour {

    public Transform seeker, target;

    GridMap grid; //ref to GridMap.cs

    private void Awake()
    {
        grid = GetComponent<GridMap>(); //get ref
    }

    private void Update()
    {
        FindPath(seeker.position, target.position);
    }

    void FindPath(Vector3 startPos, Vector3 targetPos)
    {
        Node startNode = grid.NodeFromWorldPoint(startPos);
        Node targetNode = grid.NodeFromWorldPoint(targetPos);

        List<Node> openNodes = new List<Node>();
        HashSet<Node> closedNodes = new HashSet<Node>();

        openNodes.Add(startNode);

        while(openNodes.Count > 0)
        {
            Node currentNode = openNodes[0];
            //linear search, can optimize later
            for(int i = 1; i< openNodes.Count; i++)
            {
                if(openNodes[i].fCost < currentNode.fCost || 
                   openNodes[i].fCost == currentNode.fCost && openNodes[i].hCost < currentNode.hCost)
                {
                    currentNode = openNodes[i];
                }
            }

            openNodes.Remove(currentNode);
            closedNodes.Add(currentNode);

            if(currentNode == targetNode)
            {
                RetraceOrigin(startNode, targetNode);
                return;
            }

            foreach (Node neighbour in grid.GetNeighbours(currentNode))
            {
                if (!neighbour.walkable || closedNodes.Contains(neighbour))
                    continue;

                int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
                if(newMovementCostToNeighbour < neighbour.gCost || !openNodes.Contains(neighbour))
                {
                    neighbour.gCost = newMovementCostToNeighbour;
                    neighbour.hCost = GetDistance(neighbour, targetNode);
                    neighbour.parent = currentNode;

                    if (!openNodes.Contains(neighbour))
                        openNodes.Add(neighbour);
                }
            }


        }
    }

    void RetraceOrigin(Node startNode, Node targetNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = targetNode;

        while(currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Reverse(); //flip path

        grid.path = path;
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
