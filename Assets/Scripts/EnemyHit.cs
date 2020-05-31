using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    [SerializeField] int hp = 3;
    private void OnParticleCollision(GameObject other) {
        ProcessHit();
        if(hp <= 0) {
            KillEnemy();
        }
    }
    void ProcessHit() {
        hp -= 1;
    }

    void KillEnemy() {
        Destroy(gameObject);
    }
}
