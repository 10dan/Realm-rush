using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    [SerializeField] int hp = 100;
    [SerializeField] Text healthText;

    private void Start() {
        healthText.text = hp.ToString();
    }

    private void OnTriggerEnter(Collider other) {
        hp--;
        healthText.text = hp.ToString();
    }
}
