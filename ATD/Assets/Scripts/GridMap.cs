using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridMap : MonoBehaviour {

    public GameObject gridObj;
    //public Transform enemy; //used to test and check enemy pos
    public bool displayGridGizmos;

    private Tilemap tilemap;
    private BoundsInt bounds;
    private int xBound, yBound;
    public LayerMask unwalkableMask;
    Node[,] gridStuff;

    private void Awake()
    {
        tilemap = gridObj.GetComponentInChildren<Tilemap>();
        bounds = tilemap.cellBounds;
        xBound = bounds.size.x;
        yBound = bounds.size.y+1;
        //Debug.Log(bounds.size.x);
        //Debug.Log(bounds.size.y);
        MakeNodeGrid(); //create reference grid of type Node
    }

    public int MaxSize {
        get {
            return xBound * yBound;
        }
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
                gridStuff[x, y] = new Node(walkable, gridPoint, x, y);
                //Debug.Log(gridPoint);
            }
        }
    }

    public List<Node> GetNeighbours(Node node)
    {
        List<Node> neighbours = new List<Node>();

        for(int x = -1; x <= 1; x++)
        {
            for(int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0) continue;

                int checkX = node.gridX + x;
                int checkY = node.gridY + y;

                if(checkX >= 0 && checkX < xBound && checkY >= 0 && checkY < yBound)
                {
                    neighbours.Add(gridStuff[checkX, checkY]);
                }
            }
        }
        return neighbours;
    }

    public Node NodeFromWorldPoint(Vector3 worldPos)
    {
        float percentX = (worldPos.x + bounds.size.x / 2) / bounds.size.x;
        float percentY = (worldPos.y + bounds.size.y / 2) / bounds.size.y;

        int x = Mathf.RoundToInt(bounds.size.x  * percentX);
        int y = Mathf.FloorToInt(bounds.size.y  * percentY);

        //Debug.Log("Supposed Point: " + x + ", " + y);

        //Potential issue in pathfinding because of the minus 1
        return gridStuff[x, y-1];
    }


    private void OnDrawGizmos()
    {
        //check if nodegrid is actually registering new grid points
       if (gridStuff != null && displayGridGizmos) {
            //Node enemyNode = NodeFromWorldPoint(enemy.position);
            //Debug.Log(enemy.position);
            foreach (Node n in gridStuff) {
                Gizmos.DrawCube(n.worldPosition, Vector3.one * (bounds.size.x / 10 - .1f));
                //Debug.Log("drawing cube part " + n);
            }
        }
    }
}
