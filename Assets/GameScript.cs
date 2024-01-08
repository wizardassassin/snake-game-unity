using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour {
    public FoodManager food;
    public SnakeManager snake;
    public GameObject gameOver;
    public TMP_Text scoreText;
    int score = 0;
    public void GameOver() {
        Time.timeScale = 0;
        gameOver.SetActive(true);
    }
    public void Restart() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quit() {
        Application.Quit();
    }
    public void RelocateFood() {
        score++;
        scoreText.text = "Score: " + score.ToString();
        snake.Grow();
        food.MoveFood(snake.GetCoords());
    }
}
