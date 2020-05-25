using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
    public bool isExplored = false;
    Vector2Int gridPos;
    const int gridSize = 10;

    public int GetGridSize() {
        return gridSize;
    }

    public Vector2Int GetGridPos() {
        gridPos = new Vector2Int();
        gridPos.x = Mathf.RoundToInt(transform.position.x / gridSize);
        gridPos.y = Mathf.RoundToInt(transform.position.z / gridSize);
        return gridPos;
    }

    public void SetTopColor(Color color) {
        MeshRenderer topMeshRenderer = transform.Find("top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
}
