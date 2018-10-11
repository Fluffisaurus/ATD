using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed = 10f;

    private GridMap map;
    private List<Node> path;
    private Vector3 target;
    private int index;
	// Use this for initialization
	void Awake () {
        map = GetComponent<GridMap>();
        path = map.getPath();
        target = path[index].worldPosition;
        Debug.Log(path);
    }
	
	// Update is called once per frame
	void Update () {
        //Vector3 direction = target - this.transform.position;
        //transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        //if(Vector3.Distance(transform.position, target) <= 0.1f)
        //{
        //    GetNextPathPoint();
        //}
	}

    void GetNextPathPoint()
    {
        if(index >= path.Count - 1)
        {
            Destroy(gameObject);
        }
        index++;
        target = path[index].worldPosition;
    }
}
