using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour {
    GameScript script;
    void Start() {
        script = GameObject.FindGameObjectWithTag("GameScript").GetComponent<GameScript>();
    }
    private void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("FOOD");
        script.RelocateFood();
    }
}
