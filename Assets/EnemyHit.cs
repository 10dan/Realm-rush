using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    [SerializeField] int hp = 10;
    private void OnParticleCollision(GameObject other) {
        ProcessHit();
        if(hp <= 0) {
            KillEnemy();
        }
    }
    void ProcessHit() {
        hp -= 1;
        print("Hp remaining: " + hp);
    }

    void KillEnemy() {
        Destroy(gameObject);
    }
}
