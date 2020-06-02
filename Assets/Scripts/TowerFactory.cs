using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {
    [SerializeField] int towerLimit = 3;
    [SerializeField] GameObject towerPrefab;
    Queue<GameObject> towers = new Queue<GameObject>();


    public void AddTower(Waypoint baseWaypoint) {
        if (towers.Count < towerLimit) {
            NewTower(baseWaypoint);
        } else {
            MoveTower(baseWaypoint);
        }
    }
    private void NewTower(Waypoint baseWaypoint) {
        GameObject newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        towers.Enqueue(newTower);
        baseWaypoint.isPlaceable = false;
    }

    private void MoveTower(Waypoint baseWaypoint) {
        GameObject oldTower = towers.Dequeue();
        towers.Enqueue(oldTower);
    }


}
