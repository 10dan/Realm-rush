using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {
    [SerializeField] int towerLimit = 3;
    [SerializeField] LookAtEnemy towerPrefab;
    [SerializeField] GameObject towerParent;
    [SerializeField] AudioClip hogwashSound;
    Queue<LookAtEnemy> towers = new Queue<LookAtEnemy>();


    public void AddTower(Waypoint baseWaypoint) {
        if (towers.Count < towerLimit) {
            NewTower(baseWaypoint);
        } else {
            MoveTower(baseWaypoint); 
        }
    }
    private void NewTower(Waypoint baseWaypoint) {
        LookAtEnemy newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParent.transform;

        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;
        towers.Enqueue(newTower);

    }

    private void MoveTower(Waypoint baseWaypoint) {
        LookAtEnemy oldTower = towers.Dequeue();

        oldTower.baseWaypoint.isPlaceable = true;
        baseWaypoint.isPlaceable = false;
        oldTower.transform.position = baseWaypoint.transform.position;

        towers.Enqueue(oldTower);
        AudioSource.PlayClipAtPoint(hogwashSound, oldTower.baseWaypoint.transform.position);
    }


}
