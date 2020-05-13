using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    [SerializeField] List<Block> path;
    void Start() {
        foreach(Block b in path){
            print(b.name);
        }
    }
    void Update() {

    }
}
