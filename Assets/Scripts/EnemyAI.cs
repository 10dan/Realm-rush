using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    [SerializeField] float moveWait = 1f;
    [SerializeField] ParticleSystem explodeFX;

    void Start() {
        PathFinder pathfinder = FindObjectOfType<PathFinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(Followpath(path));
    }


    IEnumerator Followpath(List<Waypoint> path) {
        foreach (Waypoint w in path) {
            transform.position = w.transform.position;
            yield return new WaitForSeconds(moveWait);
        }
        ExplodeEnemy();
    }

    private void ExplodeEnemy() {

        ParticleSystem a = Instantiate(explodeFX, transform.position, Quaternion.identity);
        a.Play();
        float aDuration = a.main.duration;
        Destroy(a.gameObject, 3f);
        Destroy(gameObject);

    }
}
