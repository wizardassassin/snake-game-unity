using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {
    public GameObject food;
    public SnakeManager snake;
    public void GameOver() {
        Time.timeScale = 0;
    }
    public void RelocateFood() {
        snake.Grow();
        food.transform.position = new Vector3(Random.Range(-17, 18) + 0.5f, Random.Range(-9, 10) + 0.5f);
    }
}
