using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

public class SnakeManager : MonoBehaviour {
    public GameObject snakePrefab;
    LinkedList<GameObject> snake = new();
    Vector3[] directions = { Vector3.zero, Vector3.up, Vector3.right, Vector3.down, Vector3.left };
    Vector3 lastPos;
    int direction = 0;
    int prevDirection = 0;
    float waitTimeMax = 0.1f;
    float currentWaitTime;
    // Start is called before the first frame update
    void Start() {
        GenerateSnake(new Vector3(-5f, 0f, 0f) + new Vector3(0.5f, 0.5f, 0f) + Vector3.left * 0);
        GenerateSnake(new Vector3(-5f, 0f, 0f) + new Vector3(0.5f, 0.5f, 0f) + Vector3.left * 1);
        GenerateSnake(new Vector3(-5f, 0f, 0f) + new Vector3(0.5f, 0.5f, 0f) + Vector3.left * 2);
        GenerateSnake(new Vector3(-5f, 0f, 0f) + new Vector3(0.5f, 0.5f, 0f) + Vector3.left * 3);
    }

    void GenerateSnake(Vector3 position) {
        var snakeCell = Instantiate(snakePrefab, position, Quaternion.identity);
        snake.AddLast(snakeCell);
    }
    void UpdateDirection() {
        if (prevDirection != 3 && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))) {
            direction = 1;
        }
        else if (prevDirection != 4 && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))) {
            direction = 2;
        }
        else if (prevDirection != 1 && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))) {
            direction = 3;
        }
        else if (prevDirection != 2 && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))) {
            direction = 4;
        }
    }

    void MoveSnake() {
        if (direction == 0) return;
        Vector3 nextPosition = snake.First.Value.transform.position + directions[direction];
        GameObject newHead = snake.Last.Value;
        lastPos = newHead.transform.position;
        newHead.transform.position = nextPosition;
        snake.RemoveLast();
        snake.AddFirst(newHead);
        prevDirection = direction;
    }

    public void Grow() {
        GenerateSnake(lastPos);
    }

    public IEnumerable<Vector3> GetCoords() {
        return snake.Select(x => x.transform.position);
    }

    // Update is called once per frame
    void Update() {
        UpdateDirection();
        currentWaitTime += Time.deltaTime;
        if (currentWaitTime >= waitTimeMax) {
            currentWaitTime = 0;
            MoveSnake();
        }
    }
}
