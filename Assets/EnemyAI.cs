using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    [SerializeField] List<Waypoint> path;
    [SerializeField] float waitTime = 1f;

    void Start() {

    }


    IEnumerator FollowPath() {
        print("Starting walk");
        foreach (Waypoint w in path) {
            transform.position = w.transform.position;
            print("Visiting: " + w.name);
            yield return new WaitForSeconds(waitTime);
        }
        print("Ending walk");
    }
}
