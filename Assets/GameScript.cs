using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {
    public FoodManager food;
    public SnakeManager snake;
    public void GameOver() {
        Time.timeScale = 0;
    }
    public void RelocateFood() {
        snake.Grow();
        food.MoveFood(snake.GetCoords());
    }
}
