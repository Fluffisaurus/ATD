using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Referenced from Sebastian Lague's A* Pathfinding Tutorial: Units

public class EnemyMovement : MonoBehaviour {
    
    public float speed = 2f;
    public Transform target;

    private GameObject lvlMngr;
    private Spawner spawner;
    private Vector3[] path;
    private int index;

    void Start() {
        lvlMngr = GameObject.Find("LevelManager");
        spawner = lvlMngr.GetComponent<Spawner>();
        target = GameObject.Find("Enemy_Move_Target").transform;
        PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
    }

    void Update() {
        //if(spawner.isPlayClicked && !spawner.isWaveSpawning) {
        //    PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
        //}
        //if (spawner.isPlayClicked) {
            
        //    PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
        //}
    }

    public void OnPathFound(Vector3[] newPath, bool pathSuccessful) {
        if (pathSuccessful) {
            path = newPath;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    IEnumerator FollowPath() {
        Vector3 currentWaypoint = path[0];

        while (true) {
            if (transform.position == currentWaypoint) {
                index++;
                if (index >= path.Length) {
                    EndPoint();
                    yield break;
                }
                currentWaypoint = path[index];
            }
            if(!gameObject.GetComponent<Enemy>().stunned)
                transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
            yield return null;
        }
    }

    void EndPoint() {
        PlayerStats.Health -= gameObject.GetComponent<Enemy>().damageToPlayer;
        Destroy(gameObject);
    }

    public void OnDrawGizmos() {
        if(path!= null) {
            for(int i = index; i<path.Length; i++) {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(path[i], new Vector3(0.4f, 0.4f, 0.4f));

                if(i == index) {
                    Gizmos.DrawLine(transform.position, path[i]);
                }
                else {
                    Gizmos.DrawLine(path[i - 1], path[i]);
                }
            }
        }
    }
}
