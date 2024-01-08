using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour {
    GameScript script;
    void Start() {
        script = GameObject.FindGameObjectWithTag("GameScript").GetComponent<GameScript>();
    }
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.layer == 3) {
            Debug.Log("SELF");
            script.GameOver();
        }
    }
}
