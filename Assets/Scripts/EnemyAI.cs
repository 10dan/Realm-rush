using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    [SerializeField] float waitTime = 1f;

    void Start() {
        PathFinder pathfinder = FindObjectOfType<PathFinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(Followpath(path));
    }


    IEnumerator Followpath(List<Waypoint> path) {
        foreach (Waypoint w in path) {
            transform.position = w.transform.position;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
