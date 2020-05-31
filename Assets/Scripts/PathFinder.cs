using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    [SerializeField] Waypoint startWaypoint, endWaypoint;
    bool isRunning = true;
    Waypoint searchCenter;
    public List<Waypoint> path = new List<Waypoint>();

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<Waypoint> GetPath() {
        if (path.Count == 0) {
            InitBlocks();
            BFS();
            CreatePath();
            return path;
        } else {
            return path;
        }
    }
    private void CreatePath() {
        path.Add(endWaypoint);
        Waypoint previous = endWaypoint.from;
        while (previous != startWaypoint) {
            path.Add(previous);
            previous = previous.from;
        }
        path.Add(startWaypoint);
        path.Reverse();
    }

    private void BFS() {
        while (queue.Count > 0 && isRunning) {
            searchCenter = queue.Dequeue();
            if (searchCenter == endWaypoint) {
                isRunning = false;
                return;
            }
            ExploreNeighbours();
        }
    }

    private void ExploreNeighbours() {
        searchCenter.isExplored = true;
        if (!isRunning) { return; }
        foreach (Vector2Int direction in directions) {
            Vector2Int currentBlock = searchCenter.GetGridPos() + direction;
            if (grid.ContainsKey(currentBlock)) {
                QueueNewNeighbours(currentBlock);
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int blockCoords) {
        Waypoint neighbour = grid[blockCoords];
        if (neighbour.isExplored || queue.Contains(neighbour)) {

        } else {
            queue.Enqueue(neighbour);
            neighbour.from = searchCenter;
        }
    }

    private void InitBlocks() {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        queue.Enqueue(startWaypoint);
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
        foreach (Waypoint waypoint in waypoints) {
            if (grid.ContainsKey(waypoint.GetGridPos())) {
                Debug.LogWarning("Overlapping block " + waypoint);
            } else {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }
    }
}
