using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] float timeBetweenSpawns = 3f;
    [SerializeField] GameObject enemy;
    public bool running = true;

    private void Start() {
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies() {
        Transform t = gameObject.transform;
        while (running) {
            Instantiate(enemy, t.position, t.rotation);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }
}
