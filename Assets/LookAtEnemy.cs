using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtEnemy : MonoBehaviour {
    [SerializeField] Transform obj;
    [SerializeField] Transform target;
    [SerializeField] float range = 5f;
    [SerializeField] ParticleSystem projectile;

    void Update() {
        if(target != null) {
            if(Vector3.Distance(obj.position, target.position) < range) {
                obj.LookAt(target);
                Shoot(true);
            } else {
                Shoot(false);
            }
        }

    }

   void Shoot(bool state) {
        var emissionMod = projectile.emission;
        emissionMod.enabled = state;
    }
}
