using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    [SerializeField] Waypoint startWaypoint, endWaypoint;
    bool isRunning = true;
    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    void Start() {
        LoadBlocks();
        ColorStartAndEnd();
        PathFind();
    }

    private void PathFind() {
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0 && isRunning) {
            var searchCenter = queue.Dequeue();
            print("Searching from " + searchCenter);
            ifEndFound(searchCenter);
            ExploreNeighbours(searchCenter);
            searchCenter.isExplored = true;
        }
        print("Stopped algorithm (pathFind())");

    }

    private void ifEndFound(Waypoint currentWaypoint) {
        if (currentWaypoint == endWaypoint) {
            print("Found it!");
            isRunning = false;
        }
    }

    private void ExploreNeighbours(Waypoint from) {
        if (!isRunning) { return; }
        foreach (Vector2Int direction in directions) {
            Vector2Int currentBlock = from.GetGridPos() + direction;
            try {
                QueueNewNeighbours(currentBlock);
            } catch (Exception e) {

            }
        }
    }

    private void QueueNewNeighbours(Vector2Int blockCoords) {
        Waypoint neighbour = grid[blockCoords];
        if (neighbour.isExplored) {

        } else {
            neighbour.SetTopColor(Color.magenta);
            queue.Enqueue(neighbour);
            print("Adding " + neighbour + " to queue.");
        }
    }

    private void ColorStartAndEnd() {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

    private void LoadBlocks() {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints) {
            if (grid.ContainsKey(waypoint.GetGridPos())) {
                Debug.LogWarning("Overlapping block " + waypoint);
            } else {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }
        print("Loaded " + grid.Count + " blocks.\n");
    }
}
