using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour {

    Vector2Int gridPos;
    TextMesh textMesh;
    Waypoint waypoint;
    int gridSize;

    private void Awake() {
        waypoint = GetComponent<Waypoint>();
        gridSize = waypoint.GetGridSize();
    }

    void Update() {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid() {
        gridPos = waypoint.GetGridPos();
        transform.position = new Vector3(gridPos.x*gridSize, 0f, gridPos.y*gridSize);
    }

    private void UpdateLabel() {
        textMesh = GetComponentInChildren<TextMesh>();
        string coords = (gridPos.x + ", " + gridPos.y);
        textMesh.text = coords;
        gameObject.name = coords;
    }
}
