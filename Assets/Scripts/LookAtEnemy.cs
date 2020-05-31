using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtEnemy : MonoBehaviour {
    [SerializeField] Transform obj;
    [SerializeField] float range = 5f;
    [SerializeField] ParticleSystem projectile;


    Transform target;

    void Update() {
        SetTargetEnemy();
        Shoot(false);
        if(target != null) {
            if(Vector3.Distance(obj.position, target.position) < range) {
                obj.LookAt(target);
                Shoot(true);
            } else {
                Shoot(false);
            }
        }

    }

    private void SetTargetEnemy() {
        var enemies = FindObjectsOfType<EnemyHit>();
        if(enemies.Length == 0) { return; }

        Transform closest = enemies[0].transform;
        foreach (EnemyHit e in enemies){
            closest = FindClosest(closest, e.transform);
        }
        target = closest;
    }

    private Transform FindClosest(Transform current, Transform test) {
        float dist1 = Vector3.Distance(transform.position, current.position);
        float dist2 = Vector3.Distance(transform.position, test.position);
        if(dist1 < dist2) {
            return current;
        } else {
            return test;
        }
    }

    void Shoot(bool state) {
        var emissionMod = projectile.emission;
        emissionMod.enabled = state;
    }
}
