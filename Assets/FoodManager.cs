using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FoodManager : MonoBehaviour {
    GameScript script;
    int xVal;
    int yVal;
    HashSet<Vector2> coords = new();
    void Start() {
        script = GameObject.FindGameObjectWithTag("GameScript").GetComponent<GameScript>();
        SetDimensions(17, 9);
    }
    private void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("FOOD");
        script.RelocateFood();
    }

    public void SetDimensions(int x, int y) {
        xVal = x;
        yVal = y;
        for (int i = -x; i < x; i++) {
            for (int j = -y; j < y; j++) {
                coords.Add(new Vector2(i, j) + new Vector2(0.5f, 0.5f));
            }
        }
    }

    public void MoveFood(IEnumerable<Vector3> locations) {
        var set = new HashSet<Vector2>(coords);
        foreach (var item in locations)
            set.Remove(item);
        Debug.Log(coords.Count);
        Debug.Log(set.Count);
        if (set.Count == 0) {
            return;
        }
        transform.position = set.ElementAt(Random.Range(0, set.Count));
        // transform.position = new Vector3(Random.Range(-17, 18) + 0.5f, Random.Range(-9, 10) + 0.5f);
    }
}
